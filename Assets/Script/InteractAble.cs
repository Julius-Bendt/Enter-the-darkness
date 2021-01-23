using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class InteractAble : MonoBehaviour {

    public GameObject container;

    public EventTrigger.TriggerEvent events;

    public string itemName;

    bool isOver = false, canAction = false;

    public string[] required;

    public AudioClip success, failed;

    public AudioSource source;

    Transform player;

    public int health = 5;

    public string text = "Press to interact";

    public bool randomPos = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (randomPos)
            f_randomPos();

    }



    void Update()
    {
        if(Vector3.Distance(transform.position,player.position) < 5)
        {
            container.SetActive(isOver);
            canAction = true;
        }
    }

    public void DestroyOnNoHealth()
    {
        bool h = true;

        foreach(string s in required)
        {
            if (!hasItem(s))
                h = false;
        }

        if(h)
        {
            source.clip = success;
            source.Play();

            health--;

            if (health <= 0)
                gameObject.SetActive(false);
        }
        else
        {
            source.clip = failed;
            source.Play();
        }

        Debug.Log("jashdkjh");

    }

    bool hasItem(string name)
    {
        GameObject o = GameObject.FindGameObjectWithTag("objectivs");

        return o.GetComponent<Objectivs>().hasItem(name);
            
    }

    void OnMouseDown()
    {
        if(canAction)
        {
            bool c = false;

            foreach(string h in required)
            {
                if (hasItem(h))
                    c = true;
            }

            if(required.Length == 0)
            {
                c = true;
            }

            if(c)
            {
                if(Time.timeScale > 0)
                {
                    container.SetActive(false);
                    BaseEventData eventData = new BaseEventData(EventSystem.current);

                    events.Invoke(eventData);

                    GameObject.FindGameObjectWithTag("objectivs").GetComponent<Objectivs>().RemoveObjectiv(itemName);
                }
               

            }


        }
    }

    void OnMouseOver()
    {
        isOver = true;

        bool h = true;

        if (manager.isPaused)
            return;

        foreach(string r in required)
        {
            if (!hasItem(r))
                h = false;
        }

        if (!h)
            container.GetComponentInChildren<Text>().text = "I need an item to do this!";
        else
            container.GetComponentInChildren<Text>().text = text;

    }

    void OnMouseExit()
    {
        isOver = false;
    }


    public void f_randomPos()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 150;
        randomDirection += player.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, 150, 1);
        transform.position = hit.position;
    }

}
