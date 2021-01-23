using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnPoint : MonoBehaviour
{
    public GameObject Boss;
    public GameObject BossHealthBar;
    public GameObject player;
    public GameObject Crates;
    public GameObject enemySpawnCount;
    public GameObject WorldStuff;
    public AudioSource levelMusic;
    public GameObject bossMusic;
    public GameController gameCntl;
    void Update()
    {
        if(player.transform.position.x > transform.position.x)
        {
            Boss.SetActive(true);
            BossHealthBar.SetActive(true);
            Destroy(enemySpawnCount);
            Crates.SetActive(true);
            levelMusic.Stop();
            bossMusic.SetActive(true);
            WorldStuff.SetActive(false);
            gameCntl.isBoss = true;
        }
        else
        {
            gameCntl.isBoss = false;
            bossMusic.SetActive(false);
        }
    }
}
