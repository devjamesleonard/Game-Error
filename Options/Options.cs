using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Options : MonoBehaviour
{
    public int selection;
    public GameManager Game;
    public GameObject Gamestate;
    public OptionsHandler handles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void operate()
    {
        if (selection == 1)
        {
            handles.Switch();
        }
        else if (selection == 2)
        {
            Game.Restart();
            Destroy(Gamestate);
           
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
   
}
