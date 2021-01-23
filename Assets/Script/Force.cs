using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {
    
    public void addForce()
    {
        GetComponent<Rigidbody>().AddForce(-transform.right * 250,ForceMode.Impulse);
    }
}
