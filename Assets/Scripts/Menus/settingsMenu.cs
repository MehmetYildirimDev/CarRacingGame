using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class settingsMenu : MonoBehaviour
{
    

    public void OnClick_Back()
    {
       MenuManager.OpenMenu(Menu.MAIN_MENU, gameObject);
    }



    
}
