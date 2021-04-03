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
    public LevelTwoCheck levelTwoChecker;
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
            levelTwoChecker.checkpointSet = false;
            CheckSaveSystem.SaveCheckpoint(levelChecker);
            CheckSaveSystem.SaveCheckpointTwo(levelTwoChecker);
            PlayerPrefs.SetInt("DeleteCount", 0);
        }

        

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            //Debug.Log("Level One");

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

        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            Debug.Log("Level Two");

            LvlOneData LvldataTwo = CheckSaveSystem.LoadLevelCheckpointTwo();

            levelTwoChecker.checkpointSet = LvldataTwo.checkpointBool;
            

            if(levelTwoChecker.checkpointSet == true)
            {
                //Debug.Log("Checkpoint");
                MainPlayerHolder.transform.position = spawnPoint.position;
            }
            else
            {
                Debug.Log("No Checkpoint");
                return;
            }
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
        //CheckSaveSystem.SaveCheckpointTwo(levelTwoChecker);
    }

    public void Load()
    {
        //GameData data = SaveSystem.LoadPlayer();

        //playerScript.bulletCount = data.bullets;
        //playerScript.health = data.health;
        //playerScript.testBool = data.testBool;

        //LvlOneData Lvldata = CheckSaveSystem.LoadLevelCheckpoint();

        //levelChecker.checkpointSet = Lvldata.checkpointBool;

        //LvlOneData LvldataTwo = CheckSaveSystem.LoadLevelCheckpointTwo();

        //levelTwoChecker.checkpointSet = LvldataTwo.checkpointBool;
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

    public void RestartLevelOne()
    {
        SceneManager.LoadScene(1);

        LvlOneData Lvldata = CheckSaveSystem.LoadLevelCheckpoint();

        levelChecker.checkpointSet = Lvldata.checkpointBool;

        Time.timeScale = 1;
    }

    public void RestartLevelTwo()
    {
        SceneManager.LoadScene(2);

        LvlOneData LvldataTwo = CheckSaveSystem.LoadLevelCheckpointTwo();

        levelTwoChecker.checkpointSet = LvldataTwo.checkpointBool;

        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void DeleteCheckpointOne()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        playerScript.transform.position = StartPoint.position;
        levelChecker.checkpointSet = false;
        CheckSaveSystem.SaveCheckpoint(levelChecker);

        ResumeGame();  
    }

    public void DeleteCheckpointTwo()
    {
        levelTwoChecker.checkpointSet = false;
        CheckSaveSystem.SaveCheckpointTwo(levelTwoChecker);
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
        playerScript.transform.position = StartPoint.position;
        ResumeGame();  
    }
}
