using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TitleController : MonoBehaviour
{

    public GameObject Controls;
    public GameObject mainMenu;
    public GameObject levelSelect;
    public Button levelTwo;
    public GameObject LockOne;
    public bool delete;
    bool turnOfCheckpoint = false;
    void Update() 
    {
        if(PlayerPrefs.GetInt("LevelCount") == 1)
        {
            levelTwo.interactable = true;
            LockOne.SetActive(false);
        }
        if(PlayerPrefs.GetInt("LevelCount") == 0)
        {
            levelTwo.interactable = false;
            LockOne.SetActive(true);
        }

        if(delete == true)
        {
            PlayerPrefs.DeleteKey("LevelCount");
        }
    }

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


    public void LevelSelect()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void LevelBackMenu()
    {
        levelSelect.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void MainMenu()
    {
        Controls.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void LevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(2);
    }

    public void deleteSave()
    {
        delete = true;
        PlayerPrefs.SetInt("DeleteCount", 1);
    }

    
    
}
