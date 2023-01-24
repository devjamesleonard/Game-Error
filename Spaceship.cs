using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    Transform t;
    float force;
    int choice;
    public GameObject g;
  //  public int a, b, c, d;
    // Start is called before the first frame update
    void Start()
    {
        t = g.GetComponent<Transform>();
        choice = Random.Range(0, 2);
        //Debug.Log(choice);
        if (choice == 0)
        {
            t.position = new Vector3(-22f, Random.Range(-2, 20 ), t.position.z);
          //  Debug.Log(t.rotation);
            t.rotation = new Quaternion(t.rotation.x  , t.rotation.y  , t.rotation.z + 1 , t.rotation.w);
            //Debug.Log(t.rotation);
            force = ((Random.Range(0, 100) / 3333f)) + .05f;
          //  Debug.Log(choice);

        }
        else
        {
            t.position = new Vector3(22f, Random.Range(-2, 20), t.position.z );
           t.rotation = new Quaternion(t.rotation.x, t.rotation.y, t.rotation.z - 1, t.rotation.w);
            force = ((-(Random.Range(0, 100)/3333f)))-.05f;
            //Debug.Log(force);
        }
       // Debug.Log(choice);
        StartCoroutine(Flyin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    IEnumerator Flyin()
    {
        while (1==1)
        {


            if (t.position.x <= -30)
            {
                Destroy(g);

            }
            else if (t.position.x >= 30)
            {
                Destroy(g);
            }
            //rb.AddForce(new Vector2(force, 0), ForceMode2D.Impulse);
            t.position = new Vector3(t.position.x + force, t.position.y, t.position.z);
           
            yield return new WaitForSeconds(.01f);

        }

    }
}
