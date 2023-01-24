using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousehitbox : MonoBehaviour
{
    public AvatarMovement avatar;
    public void Start()
    {
       // Physics.queriesHitTriggers = true;
    }
    public void OnMouseOver()
    {
       
        avatar.mouseon();
    }
}
