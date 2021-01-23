using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour {

    public Item[] items;

    public Transform[] spawnPoints;

    GameObject container;

	void Start ()
    {

        container = GameObject.FindGameObjectWithTag("interact");

	    foreach(Item item in items)
        {
            for(int i = 0; i < item.amount; i++)
            {
                GameObject o = Instantiate(item.obj) as GameObject;

                o.transform.position = randomPos();

                o.GetComponent<InteractAble>().container = container;
            }
        }
	}

    public Vector3 randomPos()
    {
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];

        Vector3 randomDirection = Random.insideUnitSphere * 250;
        randomDirection += transform.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, 250, 1);
        return hit.position;
    }
}


[System.Serializable]
public class Item
{
    public string name;
    public GameObject obj;
    public int amount;
}
