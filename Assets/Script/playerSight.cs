using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerSight : MonoBehaviour {

    public static bool enemyInSight;

    public static GameObject inSight;

    public float maxDis;

    public GameObject[] monsters;

    void Update()
    {
        foreach(GameObject monster in monsters)
        {
            if (monster == null)
                continue;

            if(Vector3.Distance(monster.transform.position,transform.position) <= maxDis)
            {
                Ray ray = new Ray(transform.position, monster.transform.position - transform.position);
                RaycastHit hit = new RaycastHit();

                Debug.DrawRay(ray.origin, ray.direction * maxDis,Color.blue);

                if(Physics.Raycast(ray,out hit,maxDis))
                {
                    if (hit.transform.GetComponent<Monster>() != null)
                    {
                        Debug.Log("raycast found " + monster.name);
                        if(Vector3.Angle(transform.forward, monster.transform.position - transform.position) <= 60)
                        {
                            Debug.Log(monster.name + " In sight.");

                            hit.transform.GetComponent<Monster>().Execute();
                        }
                        else
                        {
                            Debug.Log(monster.name + " not in sight.");
                        }
                    }
                        

                }
            }
        }
    }
}
