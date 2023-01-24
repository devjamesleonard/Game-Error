using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMovement : MonoBehaviour
{
    public float forcecoef;
    Rigidbody2D body;
    Camera cam;
    Vector2 StartPosition, EndPosition;
    public Vector2 minPower;
    public Vector2 maxPower;
    bool charging;
    Vector2 Distance;
    public TrajectoryLine tl;
    public GameObject IceMeter;
    public bool grounded;
    bool alive = true;
    public GameObject GameOver;
    public GameObject options;
    public GameManager Game;
    public Sprite[] forms;
    public GameObject Gamestate;
    Transform t;
    bool over, floorcheck, bouncin, follow;
    Transform camerat;
    float  mousex, mousey;
    Vector3 MouseLocaleStart, MouseLocaleMid;
    MeterButtons Meter;

    // Start is called before the first frame update
    void Start()
    {
       

        cam = Camera.main;
        camerat=cam.GetComponent<Transform>();
        body = this.GetComponent<Rigidbody2D>();
        tl = GetComponent<TrajectoryLine>();
        Meter = GetComponent<MeterButtons>();
      
        t = GetComponent<Transform>();
        
        

        //  body.constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(waitunfreeze());
    }
    IEnumerator waitunfreeze()
    {
        //t.position = new Vector3(t.position.x, 1, t.position.z);
        yield return new WaitForSeconds(1f);
        floorcheck = true;
       // t.position = new Vector3(-12,0 , t.position.z);
       /*
        body.constraints = RigidbodyConstraints2D.None;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        body.mass = 1;
        body.gravityScale = 3.5f;
        t.position = new Vector3(t.position.x, 1, t.position.z);

        */
    }
    public void die()
    {
        if (alive)
        {
            StartCoroutine(Game.PlaySFX(Game.gameover));
            body.constraints = RigidbodyConstraints2D.FreezeAll;
            alive = false;
            this.GetComponent<SpriteRenderer>().sprite = forms[3];
            GameOver.SetActive(true);
            options.SetActive(false);
            
            if (Game.Score > BinaryFormatt.loadBestScoreData()[0])
            {
                // new personal best
                BinaryFormatt.saveBestScoreData(Game);

            }

            for (int i = Game.last10.Length - 1; i > 0; i--)
            {
                Game.last10[i] = Game.last10[i - 1];
            }
            Game.last10[0] = (float)System.Math.Round(Game.Score, 1);
            BinaryFormatt.saveLastScoreData(Game);
            Game.deaths++;
            if((Game.deaths+1)%6==0 && Game.deaths != 0)
            {
                AdManager.instance.RequestInterstitial();
            }
            if(Game.deaths % 6 == 0 && Game.deaths != 0)
            {
                /*
                Game.ads.LoadAd();
                Game.ads.ShowAd();
*/
                AdManager.instance.ShowInterstial();
              

       
            }
            
            //Debug.Log("da");
        }
    }
    public void Grounded()
    {
        StartCoroutine(Game.PlaySFX(Game.land));
        IceMeter.SetActive(false);

        grounded = true;
        body.gravityScale = 0;
        this.GetComponent<SpriteRenderer>().sprite = forms[0];
        //Debug.Log("Grounded");
       // over = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal")
        {
            body.gravityScale = Random.Range(0f, 15f);
           // body.AddForce(new Vector2(-5, 5), ForceMode2D.Impulse);
            StartCoroutine(Game.PlaySFX(Game.laser));
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "End")
        {
            if (!over)
            {
                StartCoroutine(Game.PlaySFX(Game.powerup));
                Game.Scale();
                Destroy(Gamestate);
                over = true;
            }
        }
        if (!Game.firing)
        {

            if (collision.gameObject.tag == "Hazard")
            {
                //Debug.Log(collision.gameObject.name);
                die();
            }


        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!Game.firing)
        {

            if (collision.gameObject.tag == "Hazard")
            {
                //Debug.Log(collision.gameObject.name);
                die();
            }


        }
    }


    private void OnMouseOver()
    {
      //  mouseon();
    }


    public void Uplifted()
    {

        grounded = false;
        body.gravityScale = 3.5f;
        this.GetComponent<SpriteRenderer>().sprite = forms[2];
        
        //Debug.Log("left the ground");
    }
    // Update is called once per frame
 
    public void mouseon()
    {
        if (!Game.paused)
        {
            if (Input.GetMouseButtonDown(0) && ((float)(Input.mousePosition.y) / (float)(Screen.height) < .85))
            {


                if (!Game.firing && grounded && alive)
                {
                    IceMeter.SetActive(true);
                    StartPosition = cam.ScreenToWorldPoint(Input.mousePosition);
                    charging = true;
                    this.GetComponent<SpriteRenderer>().sprite = forms[1];
                    StartCoroutine(Game.PlaySFX(Game.charge));
                   // Debug.Log("a");

                }

            }
        }
    }
    IEnumerator bounceback()
    {
        bouncin = true;
        

        if (body.velocity.x == 0 && body.velocity.y == 0 && !grounded && floorcheck )
        {
            body.AddForce(new Vector2(-5, 5), ForceMode2D.Impulse);
          


        }
        yield return new WaitForSeconds(.1f);
        if (body.velocity.x == 0 && body.velocity.y == 0 && !grounded && floorcheck)
        {
            body.AddForce(new Vector2(5, -5), ForceMode2D.Impulse);

        }
        yield return new WaitForSeconds(.1f);
        if (body.velocity.x == 0 && body.velocity.y == 0 && !grounded && floorcheck)
        {
            body.AddForce(new Vector2(5, 5), ForceMode2D.Impulse);

        }
        bouncin = false;
     
    }
    public void started()
    {
        follow = true;
        MouseLocaleStart = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void Update()
    {
        // Debug.Log(t.position.y);
        // Screen.orientation = ScreenOrientation.LandscapeLeft;
        mouseon();
        if (!Game.paused)
        {
          //  Debug.Log(Input.mousePosition);
          if (Input.GetMouseButtonDown(0) && !follow && ((float)(Input.mousePosition.y) / (float)(Screen.height) >= .85))
            {
                started();
            
            }
            if ((Input.GetMouseButton(0) && follow))
            {
                MouseLocaleMid = cam.ScreenToWorldPoint(Input.mousePosition);
                mousex = ((MouseLocaleMid.x - MouseLocaleStart.x) / 6.8181818181818181818F) / 2;
                mousey = ((MouseLocaleMid.y - MouseLocaleStart.y) / 6.8181818181818181818F) / 2;
                //camerat = new Vector3(CameraLocaleStart.x - Mousex, CameraLocaleStart.y - Mousey, camerat.position.z);
                
                camerat.position = new Vector3(camerat.position.x - mousex, camerat.position.y - mousey, camerat.position.z);
                if(camerat.position.y < 3)
                {
                    camerat.position = new Vector3(camerat.position.x, 3,camerat.position.z);
                }else if(camerat.position.y > 5)
                {
                    camerat.position = new Vector3(camerat.position.x, 5, camerat.position.z);
                }
                if(camerat.position.x > 10)
                {
                    camerat.position = new Vector3(10, camerat.position.y, camerat.position.z);
                }
                else if(camerat.position.x < -10)
                {
                    camerat.position = new Vector3(-10, camerat.position.y, camerat.position.z);
                }
                //  CheckPosition();
               

            }
            if (Input.GetMouseButtonUp(0))
            {
                follow = false;
            }
            if (body.velocity.x == 0 && body.velocity.y == 0 && !grounded && floorcheck && !bouncin)
            {
           
                StartCoroutine(bounceback());
              
            }
           
            if (GetComponent<Transform>().position.y < -10 || Game.timevalue <= 0)
            {
               
                die();
            }
            if (Input.GetMouseButton(0) && charging && !Game.firing && alive)
            {
                Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                tl.RenderLine(StartPosition, currentPoint,gameObject.transform.position);


            }
            if (Input.GetMouseButtonUp(0) && charging && !Game.firing && alive)
            {

                StartCoroutine(Game.PlaySFX(Game.jump));
                EndPosition = cam.ScreenToWorldPoint(Input.mousePosition);
                 Distance = new Vector2(Mathf.Abs(Mathf.Clamp(StartPosition.x - EndPosition.x, minPower.x, maxPower.x)), Mathf.Abs((Mathf.Clamp(StartPosition.y - EndPosition.y, minPower.x, maxPower.x))));
               // Distance = new Vector2((Mathf.Clamp(StartPosition.x - EndPosition.x, minPower.x, maxPower.x)), (Mathf.Clamp(StartPosition.y - EndPosition.y, minPower.x, maxPower.x)));
                //Debug.Log(Mathf.Abs(Mathf.Clamp(StartPosition.x - EndPosition.x, minPower.x, maxPower.x)));
                body.AddForce(Meter.getForceCoef() * Distance, ForceMode2D.Impulse);
               // Debug.Log(Meter.getForceCoef() * Distance + "," +  Distance+ "," + Meter.getForceCoef() + ",");
                tl.EndLine();
               
                /*
                if (StartPosition.x > EndPosition.x)
                    {
                        Distance = StartPosition - EndPosition;
                    }
                    else
                    {
                        Distance = EndPosition - StartPosition;
                    }
                    float a = 1f / forcecoef;
               // body.AddForceAtPosition(ForceMode2D.Impulse,0,0);

                //body.AddForce(0, 0, ForceMode2D.Impulse);
                    body.mass = a;
                    body.AddForce(Distance);
                    */
                charging = false;


            }

        }
    }
}
