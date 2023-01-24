using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnhole : MonoBehaviour
{
    Transform t;
    public GameObject Obj;
    // Start is called before the first frame update

    void Start()
    {
        t = GetComponent<Transform>();
        t.position = new Vector3(Random.Range(-7, 8), Random.Range(0, 12), 0);
        //Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(),floor);
        StartCoroutine(Fallin());

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
           // Destroy(GetComponent<GameObject>());

        }
    }
    IEnumerator Fallin()
    {
        yield return new WaitForSeconds(Random.Range(0, 5));

        Destroy(Obj);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
