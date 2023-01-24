using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public int Projectiles;
    public int max;
    public bool firing;
    public GameObject Gameset;
    public GameObject Pregame;
    public float Score;
    public float Level;
    
    public bool paused;
    public AudioSource SFX, BG;
    public AudioMixer AudioBoard;
    public AudioClip chest, ding, door, energy, jump,charge, land, gameover, powerup, explosion, gremlin, laser, error;
    public AudioClip[] background;
    public float[] last10;
    public int deaths;

   // public interstitial ads;
    public float timevalue = 60;
    IEnumerator Setup()
    {
        StartCoroutine(PlaySFX(energy,2f));
        Instantiate(Pregame).SetActive(true);
        yield return new WaitForSeconds(2f);
            

        Instantiate(Gameset).SetActive(true);
    }
       
        // Start is called before the first frame update
        void Start()
    {
        
        float[] tempvol = new float[2];
        tempvol = BinaryFormatt.loadVolumeData();
        SFX.volume = tempvol[0];
        BG.volume = tempvol[1];

        StartCoroutine(PlayBG(background));
        /*
        VolOn = BinaryFormatt.loadVolumeData();
        StartCoroutine(PlayBG(background));
        */
        last10 = BinaryFormatt.loadLastScoreData();
        Restart();
        
    }
    void OnApplicationFocus(bool hasFocus)
    {
        paused = !hasFocus;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }

    public void Restart()
    {
        
    Projectiles = 3;
    max = 3;
    firing = true;
        Score = 0;
        Level=1;
        timevalue = 60;
       // StartCoroutine(PlaySFX(energy));
    StartCoroutine(Setup());
    }
    public void Scale()
    {
        Projectiles = Random.Range(2,5);
        max = Projectiles;
        Score+= timevalue;
        Level++;
        firing = true;
        if(Level < 10)
        {
            timevalue = 60;
        }
        else
        {
            timevalue = 90;
        }
        StartCoroutine(Setup());

    }
    // Update is called once per frame
    void Update()
    {
    
        if(timevalue > 0 && !paused)
        {
            timevalue -= Time.deltaTime;
        }
        else if(!paused)
        {
            timevalue = 0;

        }
        if(Projectiles > 0)
        {
            firing = true;
            
        }
        else
        {
            
            firing = false;
        }
        
    }
    IEnumerator PlayBG(AudioClip[] Clip)
    {
        while (1 == 1)
        {

            BG.clip = Clip[0];
            BG.Play();
            yield return new WaitForSeconds(BG.clip.length);
            BG.clip = Clip[1];
            BG.Play();
            yield return new WaitForSeconds(BG.clip.length);


        }
    }
    public IEnumerator PlaySFX(AudioClip Clip)
    {

        SFX.clip = Clip;
        SFX.Play();
        yield return new WaitForSeconds(SFX.clip.length * 2);

    }
    public IEnumerator PlaySFX(AudioClip Clip,float seconds)
    {

        SFX.clip = Clip;
        SFX.Play();
        yield return new WaitForSeconds(seconds);
        SFX.Stop();

    }
}
