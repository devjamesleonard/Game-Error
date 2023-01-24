using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legshitbox : MonoBehaviour
{
    public AvatarMovement avatar;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Ground")
        {
           avatar.Grounded();

        }
  
    
    }
    public void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            avatar.Uplifted();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
