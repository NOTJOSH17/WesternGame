using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject GameUI;
    public GameObject DeadUI;
    public GameObject PauseUI;
    public GameObject Player;
    public AudioSource levelMusic;
    public AudioSource gameOverMusic;
    public AudioSource bossMusic;
    public bool isBoss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    
    void PauseGame()
    {
        levelMusic.Pause();
        Player.SetActive(false);
        PauseUI.SetActive(true);
        Time.timeScale = 0;
        if(isBoss)
        {
            bossMusic.Pause();
        }
    }

    public void ResumeGame()
    {
        levelMusic.UnPause();
        Player.SetActive(true);
        PauseUI.SetActive(false);
        Time.timeScale = 1;
        if(isBoss)
        {
            bossMusic.Play();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void PlayerDead()
    {
        GameUI.SetActive(false);
        DeadUI.SetActive(true);
        gameOverMusic.Play();
        levelMusic.Stop();
        Time.timeScale = 0;
        if(isBoss)
        {
            bossMusic.Stop();
            
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
