using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunching : MonoBehaviour
{
    public GameManager Game;
    public MeterButtons Force;
    Vector2 StartPosition, EndPosition;
    bool charging;
    Vector2 Distance;
    Rigidbody2D body;
    Transform place;
    public float floor;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        place = this.GetComponent<Transform>();
        StartPosition = Input.mousePosition;

        charging = true;
    }

    // Update is called once per frame

    void Update()
    {

        if (place.position.y < floor)
        {
           
            place.position = new Vector3(place.position.x, floor, place.position.z);
            body.drag = 4;
       
        }
        if (Game.firing)
        {
            if (Input.GetMouseButtonUp(0) && charging && Game.firing)
            {
                body.mass = (100f / Force.currentHealth);
                EndPosition = Input.mousePosition;

                if (StartPosition.x > EndPosition.x)
                {
                    Distance = StartPosition - EndPosition;
                }
                else
                {
                    Distance = EndPosition - StartPosition;
                }

                body.AddForce(Distance);
                
                charging = false;
               

            }
            if (Game.Projectiles <= 0)
            {
                Game.firing = false;
            }
        }
    }
}
