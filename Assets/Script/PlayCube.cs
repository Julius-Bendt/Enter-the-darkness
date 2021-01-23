using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayCube : MonoBehaviour {

    public AudioSource source;
    public EventTrigger.TriggerEvent onStart;
    public EventTrigger.TriggerEvent onHalfwayStart;
    public EventTrigger.TriggerEvent onHalfwayUpdate;
    public EventTrigger.TriggerEvent onFinish;

    bool first = true, dhw = false, started = false;



	public void OnInteract()
    {
        if(!started)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            onStart.Invoke(eventData);
            source.Play();
            started = true;
        }
        
    }

    void Update()
    {
        if(source.isPlaying && source.time >= source.clip.length/2)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            if (!dhw)
            {
                dhw = true;
               
                onHalfwayStart.Invoke(eventData);
            }

            onHalfwayUpdate.Invoke(eventData);
        }

        if(!source.isPlaying && started && !manager.isPaused)
        {
            Debug.Log("On Finish");
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            onFinish.Invoke(eventData);
        }
    }
    

    public void FadeTourchToZero(GameObject obj)
    {
        Light light = obj.GetComponentInChildren<Light>() as Light;

        if (obj.GetComponentInChildren<ParticleSystem>().maxParticles < 500)
            light.intensity = Mathf.Lerp(light.intensity, 0, 0.2f * Time.deltaTime);

        obj.GetComponentInChildren<ParticleSystem>().maxParticles = (int)Mathf.Lerp(obj.GetComponentInChildren<ParticleSystem>().maxParticles, 0, 0.5f * Time.deltaTime);
    }

    public void FadeTourchToOne(GameObject obj)
    {
        Light light = obj.GetComponentInChildren<Light>() as Light;
        light.intensity = Mathf.Lerp(1.5f, light.intensity, 1 * Time.deltaTime);

        obj.GetComponentInChildren<ParticleSystem>().maxParticles = (int)Mathf.Lerp(obj.GetComponentInChildren<ParticleSystem>().maxParticles, 1000, 0.5f * Time.deltaTime);
    }
}
