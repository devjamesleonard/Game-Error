using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBlock : MonoBehaviour
{
    public GameObject[] Shapes = new GameObject[5];
    public GameManager Game;
    public int[] Projectiles;
    public int Order, count;
    public Transform position;
    public Transform Gamestate;
    public bool ready;
    
    // Start is called before the first frame update
    IEnumerator Setup()
    {
        position = this.GetComponent<Transform>();
        Projectiles = new int[Game.Projectiles];
    
        for (int i = 0; i < Game.Projectiles; i++)
        {
            Order++;
            Projectiles[i] = Random.Range(0, Shapes.Length);

            Instantiate(Shapes[Projectiles[i]], Gamestate).SetActive(true);

            yield return new WaitForSeconds(.1f);
        }

        
       
    }
    void Start()
    {
        StartCoroutine(Setup());
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (!Game.paused)
        {
            if (Game.firing)
            {

                if (Input.GetMouseButtonDown(0) && (Input.mousePosition.y < 420))
                {
                    ready = true;
                }
                if (Input.GetMouseButtonUp(0) && ready)
                {


                    Vector3 mousePosition = Input.mousePosition;
                    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                    mousePosition.z = 0;

                    if (mousePosition.x > -8 && mousePosition.x < 9)
                    {

                        StartCoroutine(Game.PlaySFX(Game.ding));
                        Instantiate(Shapes[Projectiles[count]], mousePosition, Shapes[Projectiles[count]].transform.rotation, Gamestate).SetActive(true);

                        count++;

                        Game.Projectiles--;
                    }
                    else
                    {
                        StartCoroutine(Game.PlaySFX(Game.error));
                    }
                }
            }
        }
        
    }
}
