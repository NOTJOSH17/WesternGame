using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crouch : MonoBehaviour
{

    public Transform PivotPoint;
    private Rigidbody2D rigi;
    public GameObject bullet;
    public Transform firePoint;
    bool facingRight = true;
    public static int bulletCount;
    public Text bulletText;
    public Text healthText;
    public Text totalHealthText;
    public Transform gunTransform;
    public int health;
    public int totalHealth;
    bool canShoot;
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
        bulletCount = 6;
        canShoot = true;
        totalHealthText.text = "/" + totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();
        bulletText.text = "" + bulletCount; 
        healthText.text = "" + health;

        if(canShoot == true)
        {
            if(Input.GetMouseButtonDown(0))//this just lets the player shoot.
                {
                    Shoot();
                    bulletCount -= 1; 
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
        if(bulletCount <= 0)
        {
            //emptyGun.Play();
            canShoot = false;


            if(Input.GetKey(KeyCode.R))
            {
                bulletCount = 6;
                
            }
        }
        if(bulletCount >= 1)//allows the player to shoot when they reload;
        {
            canShoot = true;
        }
        if(health <= 0)//the players health counter.
        {
            Dead();
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
            health -= 1;
            bleed();
            Hit.Play();
        }
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Explosive"))//player go boom
        {
            health -= 5;
            bleed();
            Hit.Play();
        }

    }

    void Flip()//the main flip script
    {
        facingRight = !facingRight;
        gunTransform.Rotate(0f, 180f, 0f);
        transform.Rotate(0f, 180f, 0f);
    }

    void faceMouse()//has player face mouse
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - PivotPoint.position.x, mousePosition.y - PivotPoint.position.y);
        PivotPoint.up = direction;
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

    void Dead()//get fucking owned nerd
    {
        gameCtrl.PlayerDead();
        Destroy(gameObject);
    }
}
