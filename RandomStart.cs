using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomStart : MonoBehaviour
{
    Transform body;
   public GameManager game;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Transform>();
        Vector3 position = new Vector3(body.position.x,(float)Random.Range(-4, 3),body.position.z);
        body.position = position;
      
        if (game.Level > 3)
        {
            int b = Random.Range(0, 2);
            if(b == 0)
            {
                StartCoroutine(Hoverpad());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Hoverpad()
    {

        float force = .1f;
        while (1 == 1)
        {
            if (body.position.y >= 3)
            {
                force = -.1f;
            }
            else if (body.position.y <= -4)
            {
                force = .1f;
            }
            Vector3 position = new Vector3(body.position.x, body.position.y + force, body.position.z);
            body.position = position;
            yield return new WaitForSeconds(.1f);

        }
    }
}
