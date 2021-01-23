using UnityEngine;
using System.Collections;

public class crawlerSight : MonoBehaviour {

    public Crawler c;

    void OnTriggerEnter(Collider o)
    {
        if (o.tag == "Player")
            c.inSight = true;
    }

    void OnTriggerExit(Collider o)
    {
        if (o.tag == "Player")
            c.inSight = false;
    }
}
