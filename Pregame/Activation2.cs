using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation2 : MonoBehaviour
{
    public GameObject thisobj;
    Camera cam;
    Transform t;
    IEnumerator Setup()
    {
       //thisobj = GetComponent<GameObject>();
        yield return new WaitForSeconds(2f);
        cam.orthographicSize = 9f;
        t.position = new Vector3(-2, 3, -10);
        Destroy(thisobj);

    }
    void Start()
    {
        cam = Camera.main;
        cam.orthographicSize = 3;
        t = cam.GetComponent<Transform>();
        t.position = new Vector3(-0, 0, -10);
        StartCoroutine(Setup());

    }
}
    // Start is called before the first frame update

