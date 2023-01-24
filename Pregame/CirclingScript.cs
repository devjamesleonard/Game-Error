using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclingScript : MonoBehaviour
{
    Rigidbody2D rb;
    Transform t;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
        StartCoroutine(shrinkandspin());
    }

    // Update is called once per frame
    void Update()
    {

       
    }
    IEnumerator shrinkandspin()
    {
        while (t.localScale.x > 0)
        {
            rb.SetRotation(rb.rotation + 20);

            t.localScale = new Vector3(t.lossyScale.x - .02f, t.lossyScale.y - .02f, t.lossyScale.z);
            yield return new WaitForSeconds(.015f);
            rb.SetRotation(rb.rotation + 20);
            yield return new WaitForSeconds(.015f);
        }
    }
}
