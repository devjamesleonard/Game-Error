using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Activation : MonoBehaviour
{
    public TMP_Text countdown;
    int count = 3;
    public GameObject thisobj;
    public Rigidbody2D Charac;
    public Transform Cpos, Dpos;
    public GameObject Doors1, Doors2;
    public bool stable;
    public GameObject characobj;
    IEnumerator Setup()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(.5f);
            count--;
            //countdown.text = count + "";

        }
        countdown.text = "";
        yield return new WaitForSeconds(.5f);
  
        Destroy(thisobj);

    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Setup());
    }

    // Update is called once per frame
    void Update()
    {
        if (stable)
        {
            stable = false;
            if (Doors1.activeSelf)
            {
            
                Charac.constraints = RigidbodyConstraints2D.None;
                Charac.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                Doors1.SetActive(false);
                Doors2.SetActive(true);
                characobj.SetActive(true);
                Cpos.position = Doors2.GetComponent<Transform>().position;
                Vector2 a = new Vector2(30, 100);
               
                Charac.AddForce(a,ForceMode2D.Impulse);
                
              
             
               
            }
            else
            {
                Doors2.SetActive(false);
            }

        }
    }
}
