using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootShadies : MonoBehaviour
{
    public GameObject shadie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseOver()
    {
      
        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(shadie).SetActive(true);
           
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
