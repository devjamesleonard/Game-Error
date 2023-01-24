using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadies : MonoBehaviour
{
    Transform t;
    public GameObject obj;
    private void Start()
    {
        t = GetComponent<Transform>();
        t.position = new Vector3(Random.Range(-.1f,.11f), Random.Range(-0.2f, .19f), t.position.z);
        int c = Random.Range(0, 2);
        if(c != 0)
        {
            t.rotation = new Quaternion(t.rotation.x-180, t.rotation.y, t.rotation.z, t.rotation.w);
        }
        c = Random.Range(0, 2);
        if (c != 0)
        {
            t.rotation = new Quaternion(t.rotation.x , t.rotation.y - 180, t.rotation.z, t.rotation.w);
        }
        StartCoroutine(shootacrossscreen());
    }

    IEnumerator shootacrossscreen()
    { int i = 0;
        int a = Random.Range(0, 2);
        int b = Random.Range(0, 2);
        while (i < 100)
        {
            
            if(a == 0)
            {
                t.position = new Vector3(t.position.x + .01f, t.position.y, t.position.z);
            }
            else
            {

                t.position = new Vector3(t.position.x - .01f, t.position.y, t.position.z);
            }
            if(b == 0)
            {
                t.position = new Vector3(t.position.x, t.position.y + .01f, t.position.z);
            }
            else
            {
                t.position = new Vector3(t.position.x, t.position.y - .01f, t.position.z);
            }
            yield return new WaitForSeconds(.05f);
            i++;
        }
        Destroy(obj);
}
}
