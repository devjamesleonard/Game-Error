using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public OptionsHandler handles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseOver()
    {
        
        handles.Switch();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
