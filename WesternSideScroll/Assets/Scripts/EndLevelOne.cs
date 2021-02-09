using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelOne : MonoBehaviour
{
    public SpriteRenderer horse;
    public GameObject rideHorse;
    public GameObject player;
    public Animator horseMove;
    public Animator Fader;
    public GameObject fade;
    public GameObject Credit;
    public AudioSource BossMusic;
    public LevelOneCheck levelChecker;
    public GameObject Checkpoint;
    public int addLevel;
    void Start() 
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player.SetActive(false);
            horse.enabled = false;
            rideHorse.SetActive(true);
            horseMove.Play("Horse");
            fade.SetActive(true);
            Fader.Play("FadeOut");
            BossMusic.Stop();
            Checkpoint.SetActive(false);
            levelChecker.checkpointSet = false;
            CheckSaveSystem.SaveCheckpoint(levelChecker);
            StartCoroutine(ExitButtons()); 
        }
    }

    IEnumerator ExitButtons()
    {
        yield return new WaitForSeconds(3.4f);

        if(PlayerPrefs.GetInt("LevelCount") >= 1)
        {
            PlayerPrefs.SetInt("LevelCount", PlayerPrefs.GetInt("LevelCount"));
        }
        else
        {
            addLevel = PlayerPrefs.GetInt("LevelCount");
            addLevel = 1;
            PlayerPrefs.SetInt("LevelCount", addLevel);
        }
        
        PlayerPrefs.Save();
        Credit.SetActive(true);
    }
}
