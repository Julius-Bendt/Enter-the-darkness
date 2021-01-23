using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Crawler : MonoBehaviour {

    public UnityEngine.AI.NavMeshAgent agent;

    public Transform player;

    public float radius = 99, teleportTimeMin, teleportTimeMax;

    public Image dead;

    public Animator ani;

    float timeHandler,timehandlerStart, teleportTime;

    public bool inSight;

    public GameObject sight;

    bool isDead, loading = false, p_f = false;

    Vector3 lastPos;

    ICrawlerState currentState;

    int items;


    public AudioSource source;
    public float distanceToPlayer
    {
        get
        {
            return Vector3.Distance(transform.position, player.position);
        }
    }

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();


        teleport();

        while (distanceToPlayer <= 50)
        {
            teleport();
        }
            

        ani.SetFloat("speed", 0);

        OnPickup();
	}
	
	// Update is called once per frame
	void Update ()
    {

        for (int i = 0; i < agent.path.corners.Length - 1; i++)
        {
            Debug.DrawLine(agent.path.corners[i], agent.path.corners[i + 1], Color.green);
        }

        if (agent.speed > 0)
        {
            ani.SetFloat("speed", 1);
        }
        else
        {
            ani.SetFloat("speed", 0);
        }

        if (timeHandler > teleportTime && Vector3.Distance(transform.position, player.position) > 25)
            teleport();

        if (inSight)
            isDead = true;

        if (!isDead)
            currentState.Execute();
        else
        {
            die();
        }
    }

    public void OnPickup()
    {
        items++;

        switch(items)
        {
            case 1:
                ChangeState(new ChaseState());
                break;
            case 2:
                ChangeState(new ChaseState());
                break;
            case 3:
                ChangeState(new ChaseState());
                break;

        }

        Debug.Log("New state: " + currentState);
    }

    public void setChase()
    {
        ChangeState(new ChaseState());
    }

    public void setSight(bool value)
    {
        sight.SetActive(value);
    }

    public void die(string load = "dead")
    {

        timeHandler += Time.deltaTime;

        dead.gameObject.SetActive(true);

        dead.color = Color.Lerp(dead.color, Color.black, Time.deltaTime);

        if (!p_f)
        {
            source.Play();
            p_f = true;
        }

        if (dead.color.a >= 0.9f && !loading)
        {
            loading = true;
            SceneManager.LoadSceneAsync(load, LoadSceneMode.Single);
        }
    }

    public void move(Vector3 pos)
    {
        //agent.ResetPath();
        agent.SetDestination(pos);
    }

    public void ChangeState(ICrawlerState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter(this);
    }

    public void teleport()
    {


        transform.position = randomPos();
        lastPos = transform.position;
        teleportTime = Random.Range(teleportTimeMin, teleportTimeMax);

        timeHandler = 0;
    }

    public Vector3 randomPos()
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += player.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, radius, 1);
        return hit.position;
    }
}
