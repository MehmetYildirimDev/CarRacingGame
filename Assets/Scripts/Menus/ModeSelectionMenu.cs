using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelectionMenu : MonoBehaviour
{

    public void OnClick_Back()
    {
        MenuManager.OpenMenu(Menu.MAIN_MENU, gameObject);
    }

    public void onClick_RaceMode()
    {
        SceneManager.LoadScene("RaceModeScene");
    }

    public void onClick_FuelMode()
    {
        SceneManager.LoadScene("FuelModeScene");
    }
}
