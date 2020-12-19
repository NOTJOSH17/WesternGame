using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public bool isRight;
    public GameObject player;
    public Transform seePoint;
    public EnemySpawner spawner;
    public LayerMask playerLayer;
    public bool canSpawn;
    public float seeDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowards(player.transform.position);
        RaycastHit2D hit = Physics2D.Raycast(seePoint.position, transform.TransformDirection(Vector2.right), seeDistance, playerLayer);//, ~ShootSaver
        Debug.DrawRay(seePoint.position, transform.TransformDirection(Vector2.right) * seeDistance, Color.red);

        if(canSpawn == true)
        {
            if(hit.collider.name == "Player")
            {
                spawner.spawnEnemy = true;
            }  
        }
        
    }

    private void RotateTowards(Vector2 target)
    {
        //var offset = 90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(isRight == false) 
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle));  
        } 
        if(isRight == true) 
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * (angle));  
        }     
        
    }
}
