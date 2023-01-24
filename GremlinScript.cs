using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinScript : MonoBehaviour
{

    Transform t;
    public GameObject Gremlin;
    int choice;
    public int force;
    public GameManager Game;
    public BoxCollider2D floor;
   public bool frozen;
    // Start is called before the first frame update
    void Start()
    {
     
        t = GetComponent<Transform>();
        choice = Random.Range(0, 2);
       // Debug.Log("f");
        if(choice == 0)
        {
            t.position = new Vector3(-25f, Random.Range(2, 11), t.position.z);
            t.rotation = new Quaternion(t.rotation.x, 0, t.rotation.z, t.rotation.w);
            force = 1;
        }
        else
        {
            t.position = new Vector3(25f, Random.Range(2, 11), t.position.z);
            t.rotation = new Quaternion(t.rotation.x , t.rotation.y - 180, t.rotation.z, t.rotation.w);
            force = -1;
        }
        //Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), floor);
        StartCoroutine(Flyin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            frozen = true;

        }
    }
    IEnumerator Flyin()
    {
        while (!frozen)
        {
            

            if (t.position.x <= -22)
            {
               
                force = 1;
                 t.rotation = new Quaternion(t.rotation.x, 0, t.rotation.z , t.rotation.w);

            }
            else if(t.position.x >= 22)
            {
              
                force = -1;
                t.rotation = new Quaternion(t.rotation.x, t.rotation.y - 180, t.rotation.z, t.rotation.w);
            }
            //rb.AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
            t.position = new Vector3(t.position.x + force, t.position.y, t.position.z);
            while (Game.paused)
            {
                yield return new WaitForSeconds(.1f);
            }
            yield return new WaitForSeconds(.07f);

        }

    }
}
