using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    private void Start()
    {
        MenuManager.IsInitialised = false;
    }

    public void OnClick_Settings()
    {
        MenuManager.OpenMenu(Menu.SETTINGS, gameObject);
    }


    public void OnClick_Play()
    {
        SceneManager.LoadScene("CarSelection");
    }

    public void onClick_Exit()
    {
        Application.Quit();
    }

}
