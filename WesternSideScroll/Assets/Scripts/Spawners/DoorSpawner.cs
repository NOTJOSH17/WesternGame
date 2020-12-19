using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawner : MonoBehaviour
{
    public EnemySpawner enemy;
    public Animator doorAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.spawnEnemy == true)
        {
            doorAnim.SetBool("IsOpen", true);
        }
        if(enemy.spawnEnemy == false)
        {
            doorAnim.SetBool("IsOpen", false);
        }
    }
}
