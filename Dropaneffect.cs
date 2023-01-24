using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropaneffect : MonoBehaviour
{
    public GameObject explosives;
    public GameObject[] spaceships;
    public Transform t;
    IEnumerator Explosion ()
    {

        while (1 == 1)
        {
            Transform c = explosives.GetComponent<Transform>();
            c.position = new Vector3(Random.Range(-7, 8), Random.Range(-3, 12), 0);
            Instantiate(spaceships[Random.Range(0,6)], t).SetActive(true);
                yield return new WaitForSeconds(Random.Range(0, 8));

     /*
            while (Game.paused)
            {
                yield return new WaitForSeconds(.1f);
            }
            */

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explosion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
