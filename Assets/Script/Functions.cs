using UnityEngine;
using System.Collections;

public class Functions : MonoBehaviour {

    private GameObject obj;
    private float angle;

    public void setAngle(float _angle)
    {
        angle = _angle;
    }

    public void RotateObject(GameObject _obj)
    {
        Debug.Log("sssssss");
        obj = _obj;
        StartCoroutine(rotate(obj, new Quaternion(obj.transform.rotation.x,angle,transform.rotation.z,transform.rotation.w)));
    }


    IEnumerator rotate(GameObject obj,Quaternion angle)
    {
        Debug.Log("adkjlj");
        obj.transform.rotation = angle;
        yield return null;
    }
}
