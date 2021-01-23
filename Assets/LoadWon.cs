using UnityEngine;
using System.Collections;

public class LoadWon : MonoBehaviour {

    bool loop = false;

	
    void Start()
    {
        Debug.Log(gameObject.name);
    }

    public void ChangeLoop()
    {
        loop = true;
    }

	// Update is called once per frame
	void Update ()
    {
	    if(loop)
        {
            GameObject.FindGameObjectWithTag("enemy").GetComponent<Crawler>().die("won");
        }
	}
}
