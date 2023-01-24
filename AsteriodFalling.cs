using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodFalling : MonoBehaviour
{

    Transform t;
    public GameObject asteroid;
    public BoxCollider2D floor;
    public GameManager Game;
    bool frozen;
    // Start is called before the first frame update
    void Start()
    {
  
        t = GetComponent<Transform>();
        t.position = new Vector3(Random.Range(-7,8),14,t.position.z);
        //Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(),floor);
        StartCoroutine(Fallin());

    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
           // rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            frozen = true;

        }
    }

    IEnumerator Fallin()
    {
        while (!frozen)
        {
            t.position = new Vector3(t.position.x, t.position.y -.2f, t.position.z);
            if (t.position.y < -10)
            {
                Destroy(asteroid);
                frozen = true;
               

            }

            while (Game.paused)
            {
                yield return new WaitForSeconds(.1f);
            }
            yield return new WaitForSeconds(.2f);
        }

    }
    void Update()
    {
       
    }
}
