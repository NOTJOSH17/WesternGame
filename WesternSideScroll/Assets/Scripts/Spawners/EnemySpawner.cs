using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject player;
    public Transform spawnPoint;
    public bool spawnEnemy;
    public DetectPlayer Detector;
    public float timer;
    public float maxTimer;
    public float spawnCounter;
    public float enemyCount;
    public float maxEnemyCount;

    public bool inRoom;
    public GameObject Room;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //maxTimer = 3f;
        timer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), .5f);//, ~ShootSaver
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down) * .5f, Color.red);
        
        if(hit.collider.tag == "Bandit")
        {
            Detector.canSpawn = false;
        }
        else
        {
           Detector.canSpawn = true;
           spawnCounter = 0;
        }

        if(spawnCounter >= 1)
        {
            spawnEnemy = false;
        }


        if(enemyCount >= maxEnemyCount)
        {
            spawnEnemy = false;
        }   

        if(spawnEnemy == true)
        {
            
            timer -= 1f * Time.deltaTime;
            if(timer <=0)
            {
                Spawn();
                
                timer = maxTimer;
                spawnEnemy = false; 
            }
            
        }
    }

    void Spawn()
    {
        
        

        if(inRoom)
        {   
            spawnCounter = 1f;
            enemyCount += 1;
            GameObject badGuy = Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
            badGuy.transform.parent = Room.transform;
        }
        else if (!inRoom)
        {
            spawnCounter = 1f;
            enemyCount += 1;
            Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
