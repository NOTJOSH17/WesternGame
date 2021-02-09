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
    public GameObject MainPlayerHolder;
    public PlayerCntrl playerScript;
    public Transform spawnPoint;
    public Transform StartPoint;
    public LevelOneCheck levelChecker;
    public AudioSource levelMusic;
    public AudioSource gameOverMusic;
    public AudioSource bossMusic;
    public bool isBoss;
    public GameObject bandits;
    public EnemySpawner doorSpawner;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("DeleteCount") >= 1)
        {
            //Debug.Log("Delete Save");
            levelChecker.checkpointSet = false;
            CheckSaveSystem.SaveCheckpoint(levelChecker);
            PlayerPrefs.SetInt("DeleteCount", 0);
        }

        LvlOneData Lvldata = CheckSaveSystem.LoadLevelCheckpoint();

        levelChecker.checkpointSet = Lvldata.checkpointBool;

        if(levelChecker.checkpointSet == true)
        {
            //Debug.Log("Checkpoint");
            MainPlayerHolder.transform.position = spawnPoint.position;
            bandits.SetActive(false);
            doorSpawner.enemyCount = doorSpawner.maxEnemyCount;
        }

        else
        {
            return;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
        }

        
    }

    public void Save()
    {
        //SaveSystem.SavePlayer(playerScript);
        CheckSaveSystem.SaveCheckpoint(levelChecker);
    }

    public void Load()
    {
        //GameData data = SaveSystem.LoadPlayer();

        //playerScript.bulletCount = data.bullets;
        //playerScript.health = data.health;
        //playerScript.testBool = data.testBool;

        LvlOneData Lvldata = CheckSaveSystem.LoadLevelCheckpoint();

        levelChecker.checkpointSet = Lvldata.checkpointBool;
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

        LvlOneData Lvldata = CheckSaveSystem.LoadLevelCheckpoint();

        levelChecker.checkpointSet = Lvldata.checkpointBool;

        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void DeleteCheckpoint()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        playerScript.transform.position = StartPoint.position;
        levelChecker.checkpointSet = false;
        CheckSaveSystem.SaveCheckpoint(levelChecker);

        ResumeGame();

        
    }
}
