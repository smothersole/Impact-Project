using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    
    public GameObject hudUI;

    // Update is called once per frame
    void Update()
    {
        if(pause_menu.IsPaused)
        {
            hudUI.SetActive(false);
        }
    }
}
