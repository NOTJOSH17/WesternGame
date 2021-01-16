using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMover : MonoBehaviour
{
    public GameObject player;
    public GameObject Enemy;
    public BossCntrl bossController;
    public Vector3 enemyStartPos;
    public Transform movePointLeft;
    public Transform movePointRight;
    public Transform upperPoint;
    public Transform lowerPoint;
    public Transform BanditSpawner;
    public float moveTimer;
    public float maxMoveTimer;
    public bool moveUp;
    public int moveCount;
    void Start()
    {
        //Enemy.transform.position = enemyStartPos;
        moveTimer = maxMoveTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //if(player.transform.position.x < transform.position.x)
        //{
            //FlipLeft();
        //}
        //if(player.transform.position.x > transform.position.x)
        //{
            //FlipRight();
        //}

        if(bossController.hitCounter >= 10) //eventually set hit count to an actual int!
        {
            moveTimer -= 1 * Time.deltaTime;
            if(moveUp == false)
            {
                MoverDown();
            }
            if(moveUp == true)
            {
                MoverUp();
            }
            if(moveCount >= 1)
            {
                moveUp = true;
            }
            if(moveCount >= 2)
            {
                moveUp = false;
                moveCount = 0;
            }
        }
    }

    void MoverDown()
    {
        Enemy.SetActive(false);
        
        if(moveTimer <= 0)
        {
            bossController.hitCounter = 0;
            Enemy.transform.position = lowerPoint.position;
            Enemy.SetActive(true);
            moveTimer = maxMoveTimer;
            moveCount += 1;
        }
    }
    void MoverUp()
    {
        Enemy.SetActive(false); 

        if(moveTimer <= 0)
        {
            bossController.hitCounter = 0;
            Enemy.transform.position = upperPoint.position;
            Enemy.SetActive(true);
            moveTimer = maxMoveTimer;
            moveCount += 1;
        }
    }

    void FlipLeft()
    {
        //Debug.Log("move left");
        Enemy.transform.position = movePointLeft.position;
    }

    void FlipRight()
    {
        //Debug.Log("move right");
        Enemy.transform.position = movePointRight.position;
    }
    
}
