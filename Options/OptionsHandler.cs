using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsHandler : MonoBehaviour
{

    
    public GameObject Options;
    public GameObject GameOver;
    public GamestateHandler Gamestate;
    // Start is called before the first frame update
    void OnApplicationFocus(bool pauseStatus)
    {
        Gamestate.Game.paused = pauseStatus;
    }
    public void Switch()
    {
        if (Options.activeSelf )
        {
            Options.SetActive(false);
            Gamestate.Game.paused = true;
            StartCoroutine(Gamestate.Game.PlaySFX(Gamestate.Game.chest));
        }
        else if(!GameOver.activeSelf)
        {
            StartCoroutine(Gamestate.Game.PlaySFX(Gamestate.Game.chest));
            Options.SetActive(true);
            Gamestate.Game.paused = true;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Gamestate.Game.paused = Options.activeSelf;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Switch();

        }

    }
}
