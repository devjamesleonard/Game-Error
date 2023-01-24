using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosivesScript : MonoBehaviour
{
    public GameObject g;
  
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Begone());
   
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Begone()
    {

        yield return new WaitForSeconds(1f);
       Destroy(g);

        

    }
}
