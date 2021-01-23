using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class Scare : MonoBehaviour {

    public AudioClip clip;

    public AudioSource source;

    public EventTrigger.TriggerEvent events;

    public bool disable = false;

    void Start()
    {
        if(source == null)
            source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider o)
    {
        if (o.tag == "Player")
        {
            source.clip = clip;
            source.Play();


            BaseEventData eventData = new BaseEventData(EventSystem.current);
            events.Invoke(eventData);

            gameObject.SetActive(disable);
        }
    }

}
