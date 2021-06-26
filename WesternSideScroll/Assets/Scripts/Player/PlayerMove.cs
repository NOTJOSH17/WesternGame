using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Transform PivotPoint;
    private Rigidbody2D rigi;
    public GameObject bullet;
    public Transform firePoint;
    bool facingRight = true;
    public Transform gunTransform;
    public PlayerCntrl playerController;
    public bool canShoot;
    public AudioSource gunSounds;
    public AudioSource emptyGun;
    public AudioSource Hit;
    public GameObject Blood;
    public Transform bleedingPoint;
    public ParticleSystem Flash;
    public GameController gameCtrl;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();

        if(canShoot == true)
        {
            if(Input.GetMouseButtonDown(0))//this just lets the player shoot.
                {
                    Shoot();
                    playerController.bulletCount -= 1; 
                    gunSounds.Play();
                }
        }
        if(canShoot == false)
        {
            if(Input.GetMouseButtonDown(0))//this just lets the player shoot.
                {
                    emptyGun.Play();
                }
        }
        //bullet count for player. counts to see how many shots that player has taken.
        if(playerController.bulletCount <= 0)
        {
            //emptyGun.Play();
            canShoot = false;


            //if(Input.GetKey(KeyCode.R))
            //{
            //    playerController.bulletCount = playerController.maxBulletCount;
                
            //}
        }
        if(playerController.bulletCount >= 1)//allows the player to shoot when they reload;
        {
            canShoot = true;
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//tracks the players mouse to see if its on the left or right of the player.

        if(mousePos.x < transform.position.x && facingRight)//flips the player right
        {
            Flip();
        }
        if(mousePos.x > transform.position.x && !facingRight)//flips the player left
        {
            Flip();
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))//sees if the player is shot, takes damage
        {
            playerController.health -= 1;
            bleed();
            Hit.Play();
        }
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Ammo"))//player go boom
        {
            playerController.bulletCount += 6;

            if(playerController.bulletCount >= playerController.maxBulletCount)
            {
                playerController.bulletCount = playerController.maxBulletCount;
            }
        }


    }

    void Flip()//the main flip script
    {
        facingRight = !facingRight;
        //gunTransform.Rotate(0f, 180f, 0f);
        transform.Rotate(0f, 180f, 0f);
    }

    void faceMouse()//has player face mouse
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - PivotPoint.position.x, mousePosition.y - PivotPoint.position.y);
        //PivotPoint.up = direction;
    }

    void Shoot()//main shoot function
    {

        Flash.Play();
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    void bleed()//bleeds
    {
        Instantiate(Blood, bleedingPoint.position, bleedingPoint.rotation);
    }

}
