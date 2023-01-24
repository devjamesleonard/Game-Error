using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MenuHandler : MonoBehaviour
{
    public GameObject help;
    public GameObject options;
    public GameObject record;
    public GameObject mainmenu;
    public AudioSource SFX, BG;
    public AudioMixer AudioBoard;
    public AudioClip chest, ding, door;
    public Text besttext, tentext;
    public AudioClip[] background;
    public Slider slider1, slider2;
  //  public banner ban;
    public float bgvolume, sfxvolume;

    public void startGame()
    {
        AdManager.instance.destroyBan();
        StartCoroutine(PlaySFX(chest));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    /*
    public void showBanner()
    {
        ban.LoadBanner();
        ban.ShowBannerAd();
    }
    */
    public void helpMenu()
    {
       
        if (help.activeSelf)
        {
            StartCoroutine(PlaySFX(chest));
            help.SetActive(false);
            mainmenu.SetActive(true);
          //  ban.HideBannerAd();

        }
        else
        {
            StartCoroutine(PlaySFX(chest));
            help.SetActive(true);
            mainmenu.SetActive(false);
           // showBanner();
        } 
    }
    public void optionsMenu()
    {
       
        if (options.activeSelf)
        {

            StartCoroutine(PlaySFX(chest));
            options.SetActive(false);
            mainmenu.SetActive(true);
            BinaryFormatt.saveVolumeData(this);
          //  ban.HideBannerAd();
        }
        else
        {
         //   showBanner();
            StartCoroutine(PlaySFX(chest));
            options.SetActive(true);
            mainmenu.SetActive(false);
      
        }
    }
    public void recordMenu()
    {
        
        float a = BinaryFormatt.loadBestScoreData()[0];
        float c = BinaryFormatt.loadBestScoreData()[1];
        besttext.text =  a +  "\nLvl: " + c;
        float[] b = BinaryFormatt.loadLastScoreData();
        if (b[0] != -1)
        {
            tentext.text = "";
            for (int i = 0; i < b.Length; i++)
            {

                if (b[i] == -1)
                {
                    break;
                }else if (b[i] != 0)
                {
                    tentext.text += b[i] + "\n";
                }
           
                
            }
        }
        else
        {
            tentext.text = "No Games";
        }
        if (record.activeSelf)
        {
            StartCoroutine(PlaySFX(chest));
            record.SetActive(false);
            mainmenu.SetActive(true);
           // ban.HideBannerAd();
        }
        else
        {
         //   showBanner();
            StartCoroutine(PlaySFX(chest));
            record.SetActive(true);
            mainmenu.SetActive(false);
        }
    }
    public void changebgVolume(Slider slide)
    {
       // StartCoroutine(PlaySFX(ding));
        bgvolume = slide.value;
        BG.volume = bgvolume;
    }
    public void changesfxVolume(Slider slide)
    {
        //StartCoroutine(PlaySFX(chest));
        sfxvolume = slide.value;
        SFX.volume = sfxvolume;
    }
    public void exitMenu()
    {
        StartCoroutine(PlaySFX(chest));
        Application.Quit();
    }
    private void OnApplicationFocus(bool focus)
    {
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }
    // Start is called before the first frame update
    void Start()
    {

        float[] tempvol = new float[2];
        tempvol = BinaryFormatt.loadVolumeData();
        sfxvolume = tempvol[0];
        bgvolume = tempvol[1];
        BG.volume = bgvolume;

        SFX.volume = sfxvolume;
        StartCoroutine(PlayBG(background));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && mainmenu.activeSelf)
        {
            exitMenu();

        }
        if (Input.GetKeyDown(KeyCode.Escape) && help.activeSelf)
        {
            helpMenu();

        }
        if (Input.GetKeyDown(KeyCode.Escape) && record.activeSelf)
        {
            recordMenu();

        }
        if (Input.GetKeyDown(KeyCode.Escape) && options.activeSelf)
        {
            optionsMenu();

        }



        slider1.value = bgvolume;
        slider2.value = sfxvolume;
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

    IEnumerator PlaySFX(AudioClip Clip)
    {

        SFX.clip = Clip;
        SFX.Play();
        yield return new WaitForSeconds(SFX.clip.length * 2);

    }

}
