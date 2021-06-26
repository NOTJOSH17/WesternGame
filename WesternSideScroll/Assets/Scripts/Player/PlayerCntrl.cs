using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCntrl : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigi;
    public GameObject PlayerMove;
    public GameObject playerCrouch;
    public int bulletCount;
    public int maxBulletCount;
    public int clipCount;
    public int maxClipCount;
    public Text bulletText;
    public Text healthText;
    public Text totalHealthText;
    public int health;
    public int totalHealth;
    public GameObject Blood;
    public Transform bleedingPoint;
    public ParticleSystem Flash;
    public GameController gameCtrl;
    public float jumpVelocity;
    public bool canJump;
    bool isCrouching;
    public GameObject enemyAimPoint;
    public Transform standPos;
    public Transform crouchPos;
    public bool needReload;
    public bool canReload;
    public float gravity;
    public float tempGravity = 0.0f;
    public bool testBool;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        bulletCount = maxBulletCount;

        maxBulletCount = 6;
        totalHealthText.text = "/" + totalHealth;
        gravity = this.rigi.gravityScale;
    }

    private void FixedUpdate() 
    {
        
        //Main Movement
        
        float moveVertical = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump"); //not currenty used

        //Vector2 movement = new Vector2 (moveHorizontal, 0);


        //rigi.AddForce(movement * speed * Time.deltaTime - rigi.velocity); //movement

        //rigi.velocity = movement * speed * Time.deltaTime - rigi.velocity;   
    }

    private void Update() 
    {   

        float moveHorizontal = Input.GetAxis("Horizontal");
        if(isCrouching == false)
        {
            if(Input.GetButton("Horizontal"))
            {
                rigi.velocity = new Vector2((moveHorizontal * speed),rigi.velocity.y);
            }

                if(canJump == true) //player can jump
                {
                    if(Input.GetButtonDown("Jump"))
                    {    
                        rigi.velocity = Vector2.up * jumpVelocity * 5;
                    } 
                }
        }


        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerMove.SetActive(false);
            enemyAimPoint.transform.position = crouchPos.transform.position;
            playerCrouch.SetActive(true);
            isCrouching = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            PlayerMove.SetActive(true);
            enemyAimPoint.transform.position = standPos.transform.position;
            playerCrouch.SetActive(false);
            isCrouching = false;
        }

        if(Input.GetMouseButtonDown(0))//this just lets the player shoot.
        {
            if(PlayerMove.GetComponent<PlayerMove>().canShoot == true)
            {
                Flash.Play();
            }
            else
            {
                Flash.Stop();
            }
            
        }

        if(health <= totalHealth - 1)
        {
            
        } 


        bulletText.text = "" + bulletCount; 
        healthText.text = "" + health;

        //First gun
        if(bulletCount <= maxBulletCount - 1)// negative one so that it the player can reload at any number below the max amount of bullets
        {
            needReload = true;
        }
        else if(bulletCount >= maxBulletCount)//the player doenst need to reload because they have the max amount
        {
            needReload = false;
        }

        if(clipCount >= 1 && bulletCount <= maxBulletCount - 1)
        {
            canReload = true;
        }
        else
        {
            canReload = false;
        }

        
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(canReload == true)
            {
                clipCount -= 1;
                bulletCount = maxBulletCount;
                if(clipCount <= 0)
                {
                    clipCount = 0;
                    canReload = false;
                }
            }
            
        }


        if(health <= 0)//the players health counter.
        {
            Dead();
        }
    }

    public void Climb()
    {
        this.rigi.gravityScale = tempGravity;
        if(Input.GetKey(KeyCode.Space))
        {
            rigi.velocity = Vector2.up * 4;
        }
        else
        {
            rigi.velocity = Vector2.down * 2;
        }
    }
    
    public void ExitClimb()
    {
        this.rigi.gravityScale = gravity;
    }

    void bleed()//bleeds
    {
        Instantiate(Blood, bleedingPoint.position, bleedingPoint.rotation);
    }

    void Dead()//get fucking owned nerd
    {
        gameCtrl.PlayerDead();
        Destroy(gameObject);
    }

}
