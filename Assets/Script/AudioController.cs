using UnityEngine;
using System.Collections.Generic;

public class AudioController : MonoBehaviour {

    AudioSource[] sources;

    public void Start()
    {

        sources = GameObject.FindObjectsOfType<AudioSource>();
    }



	// Update is called once per frame
	public void trigger (float time)
    {
        Start();

	    if(time > 0) //Play
        {
            foreach(AudioSource s in sources)
            {
                s.UnPause();
            }
        }
        else if(time < 1) //pause
        {
            foreach (AudioSource s in sources)
            {
                s.Pause();
            }
        }
	}
}

