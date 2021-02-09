using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMover : MonoBehaviour
{
    public GameObject player;
    public GameObject Enemy;
    public GameObject Bandit;
    public BossCntrl bossController;
    public Vector3 enemyStartPos;
    public Transform moveUpPointLeft;
    public Transform moveUpPointRight;
    public Transform moveDownPointLeft;
    public Transform moveDownPointRight;
    public Transform upperPoint;
    public Transform lowerPoint;
    public Transform banditSpawnerLeft;
    public Transform banditSpawnerRight;
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
        if(moveUp == false)
        {
            if(player.transform.position.x < transform.position.x)
            {
                FlipLeftUp();
            }
            if(player.transform.position.x > transform.position.x)
            {
                FlipRightUp();
            }    
        }
        if(moveUp == true)
        {
            if(player.transform.position.x < transform.position.x)
            {
                FlipLeftDown();
            }
            if(player.transform.position.x > transform.position.x)
            {
                FlipRightDown();
            }    
        }

        if(bossController.hitCounter >= 10) //eventually set hit count to an actual int and not a set value here!
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
            BanditSpawer();
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

    void FlipLeftUp()
    {
        Enemy.transform.position = moveUpPointLeft.position;
    }

    void FlipRightUp()
    {
        Enemy.transform.position = moveUpPointRight.position;
    }
    
    void FlipLeftDown()
    {
        Enemy.transform.position = moveDownPointLeft.position;
    }

    void FlipRightDown()
    {
        Enemy.transform.position = moveDownPointRight.position;
    }

    void BanditSpawer()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(banditSpawnerLeft.position, banditSpawnerLeft.TransformDirection(Vector2.down), .5f);
        if(leftHit.collider.tag != "Bandit")
        {
            Instantiate(Bandit, banditSpawnerLeft.position, banditSpawnerLeft.rotation);
        }
        
        RaycastHit2D rightHit = Physics2D.Raycast(banditSpawnerRight.position, banditSpawnerRight.TransformDirection(Vector2.down), .5f);
        if(rightHit.collider.tag != "Bandit")
        {
            Instantiate(Bandit, banditSpawnerRight.position, banditSpawnerRight.rotation);
        }
       
    }
}
