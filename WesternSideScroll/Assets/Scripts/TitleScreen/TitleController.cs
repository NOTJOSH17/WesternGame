using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{

    public GameObject Controls;
    public GameObject mainMenu;

    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void ControlMenu()
    {
        Controls.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void MainMenu()
    {
        Controls.SetActive(false);
        mainMenu.SetActive(true);
    }
}
