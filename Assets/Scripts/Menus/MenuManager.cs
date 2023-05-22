using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuManager
{
    //public static bool IsInitialised { get; private set;}
    public static bool IsInitialised;
    public static GameObject mainMenu, settingsMenu;
    public static void Init()
    {
        GameObject Canvas = GameObject.Find("Canvas");//safearea = canvas

        mainMenu = Canvas.transform.Find("MainMenu").gameObject;
        settingsMenu = Canvas.transform.Find("SettingsMenu").gameObject;

        IsInitialised = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if (!IsInitialised)
            Init();

        switch (menu)
        {
            case Menu.MAIN_MENU:
                mainMenu.SetActive(true);
                break;
            case Menu.SETTINGS:
                settingsMenu.SetActive(true);
                break;
            default:
                break;
        }

        callingMenu.SetActive(false);
    }

}
