using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyonSpawn : MonoBehaviour
{
    public PlaceBlock Place;
    public int position = 100;
    Transform transforms;
    public Transform character;
    public GameObject Obj;
    
    // Start is called before the first frame update
    void Start()
    {
        
        if (Place.Game.Projectiles == Place.Game.max)
        {
            position = Place.Order;
            transforms = this.GetComponent<Transform>();
            Quaternion Rotation = new Quaternion(0, 0, 0, 0);
            Vector3 newpos = new Vector3((character.position.x - Place.Game.max +1) + (position), 4, character.position.z);
            transforms.localScale = new Vector3((transforms.localScale.x / 4f), (transforms.localScale.y / 4f), (transforms.localScale.z / 4f));
            transform.localPosition = newpos;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Place.Game.firing)
        {
          
            if (Input.GetMouseButtonUp(0) && Place.ready)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                mousePosition.z = 0;
               
                if (mousePosition.x > -8 && mousePosition.x < 9)
                {
                    position--;
                }
              
            }
            if (position <= 0)
            {
                
                Destroy(this);
                Destroy(Obj);

            }
        }
        else
        {
            Destroy(this);
            Destroy(Obj);
        }
    }
}
