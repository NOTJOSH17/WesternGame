using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondGun : MonoBehaviour
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
    public ParticleSystem Flash;
    public GameController gameCtrl;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();

        if(canShoot == true)
        {
            if(Input.GetMouseButtonDown(1))//this just lets the player shoot.
                {
                    Shoot();
                    gunSounds.Play();
                }
        }
        if(canShoot == false)
        {
            if(Input.GetMouseButtonDown(1))//this just lets the player shoot.
                {
                    emptyGun.Play();
                }
        }
        //bullet count for player. counts to see how many shots that player has taken.


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

    void Flip()//the main flip script
    {
        facingRight = !facingRight;
        gunTransform.Rotate(0f, 180f, 0f);
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
}
