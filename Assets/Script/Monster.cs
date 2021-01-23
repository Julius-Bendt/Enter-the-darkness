using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Monster : MonoBehaviour {

    public AudioSource source;

    public float destroyTime = 1, agentSpeed = 3, despawnDis = 3;

    public EventTrigger.TriggerEvent events;

    bool loop, triggered;

    Transform player;

    public bool debug;

    Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        source = GetComponent<AudioSource>();

        if (debug)
        {
            Execute();
            destroyTime = 1000000000000;
        }

        anim = GetComponent<Animator>();
           
    }


    void Update()
    {
        if(loop)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            events.Invoke(eventData);
        }
    }

    public void Execute()
    {
        BaseEventData eventData = new BaseEventData(EventSystem.current);
        events.Invoke(eventData);
    }

	public void Scare()
    {
        if(!source.isPlaying && source != null)
        {
            source.Play();
            Destroy(gameObject, destroyTime);
        }
    }

    public void FollowPlayer()
    {
        UnityEngine.AI.NavMeshAgent agent;
        if(!triggered) //Start
        {
            agent = gameObject.AddComponent<UnityEngine.AI.NavMeshAgent>();
            agent.speed = agentSpeed;


            Destroy(gameObject, destroyTime);
            triggered = true;
            loop = true;

        }
        //else Update

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        agent.SetDestination(player.position);

        if (anim != null)
            anim.SetFloat("speed", agent.speed);


        if (Vector3.Distance(player.position,transform.position) < despawnDis)
        {
            Destroy(gameObject);
        }


    }
}
