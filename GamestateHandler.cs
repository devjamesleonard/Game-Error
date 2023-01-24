using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamestateHandler : MonoBehaviour
{
    public GameManager Game;
    public Text text;
    public Text level;
    public Text timer;
    public Text projectiles;
    public GameObject Gem;
    public Image Gems;
    public Sprite Arrow;
    int activate;
    //public GameObject EndZone;
    public GameObject[] Asteroids;
    public GameObject Gremlin;
    public Transform t;
    public GameObject portal;

    private List<GameObject> onScreenParticles = new List<GameObject>();
    /*
    void OnApplicationFocus(bool pauseStatus)
    {
        if (!pauseStatus)
        {
            if (!pause)
            {
                resume();
            }

        }
    }
    */
    // Start is called before the first frame update
    IEnumerator FlickerSprite ()
    {
        while(Game.Projectiles > 0)
        {
            Gem.SetActive(true);
            yield return new WaitForSeconds(.8f);
            Gem.SetActive(false);
            yield return new WaitForSeconds(.3f);
        }
        Gems.sprite = Arrow;
    
            Gem.SetActive(true);
        
        



    }
        void Start()
    {
        StartCoroutine(FlickerSprite());
        t = GetComponent<Transform>();
         if(Game.Level >= 30){
            activate = Random.Range(6,8);
       
        }
        else if (Game.Level >= 25)
        {
            activate = Random.Range(4, 8);

        }
        else if (Game.Level >= 20)
        {
            activate = Random.Range(0, 8);

        }
        else if (Game.Level >= 15){
            activate = Random.Range(0, 7);
       
        }
        else if (Game.Level >= 10) {
            activate = Random.Range(0, 4);

        }else if(Game.Level >= 5)
        {
            activate = Random.Range(0, 3);
         


        }
        else if (Game.Level >= 2)
        {
            activate = Random.Range(0, 2);
         
        }
        CheckUp();
       // StartCoroutine(PortalSpawner());
    }
    public void CheckUp()
    {
       // activate = 7;
       // activate = 1;
        if (activate == 1)
        {
            StartCoroutine(PortalSpawner());
          
        }else if(activate == 2)
        {
            StartCoroutine(AsteroidSpawner());
          
        }else if(activate == 3)
        {
            StartCoroutine(DragonSpawner());
       
        }else if(activate == 4)
        {
            StartCoroutine(PortalSpawner());
            StartCoroutine(AsteroidSpawner());
        }
        else if(activate == 5)
        {
            StartCoroutine(DragonSpawner());
            StartCoroutine(PortalSpawner());
        }
        else if(activate == 6)
        {
            StartCoroutine(DragonSpawner());
            StartCoroutine(AsteroidSpawner());

        }else if(activate == 7)
        {
            StartCoroutine(PortalSpawner());
            StartCoroutine(AsteroidSpawner());
            StartCoroutine(DragonSpawner());
        }
    }
   
    IEnumerator PortalSpawner()
    {

        while (1 == 1)
        {
            GameObject particle = spawnParticle();

            particle.transform.position = new Vector3(Random.Range(-7,8), Random.Range(0, 12), 0) + particle.transform.position;

            if (Game.Level > 15)
            {
                yield return new WaitForSeconds(Random.Range(1, 5));
            }
            else if (Game.Level > 12)
            {
                yield return new WaitForSeconds(Random.Range(1, 9));
            }
            else if (Game.Level > 6)
            {
                yield return new WaitForSeconds(Random.Range(2, 10));
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(3, 12));
            }
            while (Game.paused)
            {
                yield return new WaitForSeconds(.1f);
            }

        }
    }
        IEnumerator DragonSpawner()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        Instantiate(Gremlin, t);
        StartCoroutine(Game.PlaySFX(Game.gremlin));
        if (Game.Level > 9)
        {
            yield return new WaitForSeconds(Random.Range(2, 8));
            Instantiate(Gremlin, t);
            StartCoroutine(Game.PlaySFX(Game.gremlin));
        }
        if (Game.Level > 13)
        {
            yield return new WaitForSeconds(Random.Range(0, 8));
            Instantiate(Gremlin, t);
            StartCoroutine(Game.PlaySFX(Game.gremlin));
        }

    }
    IEnumerator AsteroidSpawner()
    {

        while (1==1)
        {
            Instantiate(Asteroids[Random.Range(0, 3)], t);
            StartCoroutine(Game.PlaySFX(Game.explosion));
            if (Game.Level > 15)
            {
                yield return new WaitForSeconds(Random.Range(2, 3));
            }
            else if(Game.Level > 12)
            {
                yield return new WaitForSeconds(Random.Range(2, 4));
            }
            else if (Game.Level > 6)
            {
                yield return new WaitForSeconds(Random.Range(2, 6));
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(2, 8));
            }
            while (Game.paused)
            {
                yield return new WaitForSeconds(.1f);
            }

        }
        //Instantiate(Asteroids[Random.Range(0, 3)], t);
        
    }
    private GameObject spawnParticle()
    {
        GameObject particles = (GameObject)Instantiate(portal,t);
        particles.transform.position = new Vector3(0, particles.transform.position.y, 0);
#if UNITY_3_5
			particles.SetActiveRecursively(true);
#else
        particles.SetActive(true);
        //			for(int i = 0; i < particles.transform.childCount; i++)
        //				particles.transform.GetChild(i).gameObject.SetActive(true);
#endif

        ParticleSystem ps = particles.GetComponent<ParticleSystem>();

#if UNITY_5_5_OR_NEWER
        if (ps != null)
        {
            var main = ps.main;
            if (main.loop)
            {
                ps.gameObject.AddComponent<CFX_AutoStopLoopedEffect>();
                ps.gameObject.AddComponent<CFX_AutoDestructShuriken>();
            }
        }
#else
		if(ps != null && ps.loop)
		{
			ps.gameObject.AddComponent<CFX_AutoStopLoopedEffect>();
			ps.gameObject.AddComponent<CFX_AutoDestructShuriken>();
		}
#endif

        onScreenParticles.Add(particles);

        return particles;
    }
    // Update is called once per frame
    void Update()
    {
        text.text = System.Math.Round(Game.Score, 1) + "";
        timer.text = System.Math.Round(Game.timevalue,1) + "";
        level.text = Game.Level + "";
        if (Game.Projectiles > 0)
        {
            projectiles.text = Game.Projectiles + "";
        }
        else
        {
            projectiles.text = "";
        }
    }
}
