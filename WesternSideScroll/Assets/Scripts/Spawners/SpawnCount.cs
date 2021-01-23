using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCount : MonoBehaviour
{
    public EnemySpawner count;
    public GameObject Crates;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), .5f);
        if(count.enemyCount >= count.maxEnemyCount && hit.collider.tag != "Bandit")
        {
            Crates.SetActive(false);
        }
    }
}
