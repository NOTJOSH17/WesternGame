using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpCntrl : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public Transform firePoint;
    public AudioSource gunSounds;
    public AudioSource hit;
    public GameObject Blood;
    public Transform bleedingPoint;
    public ParticleSystem Flash;
    public int sharpHealth;
    public bool startShooting;
    public bool canShoot;
    public float timer;
    public float startTimer;
    public SharpGun arm;
    public float leftFlipY;//for whem I change the rotation y of tall train cart
    public float rightFlipY;//Same /\
    public bool inRoom;
    public GameObject Spawner;

    // Start is called before the first frame update
    void Start()
    {
        timer = startTimer;
        player = GameObject.FindGameObjectWithTag("Player");
        
        // canSeePlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //checks to see if enemy can shoot
        if(startShooting == true && canShoot == true)
        {
            timer -= 1f * Time.deltaTime;
        }
        //when timer runs out, they shoot
        if(timer <= 0)
        {
            Shoot();
            timer = startTimer;
        }
        

        //bandits health, if zero, starts death
        if(sharpHealth <= 0)
        {   
            StartCoroutine(death());
        }

        //this checks to see if the player is left or right of the player, then flips enemy towards player
        if(player.transform.position.x < transform.position.x)
        {
            FlipLeft();
        }
        if(player.transform.position.x > transform.position.x)
        {
            FlipRight();
        }
    }

    IEnumerator death()
    { 
        if(!inRoom)
        {
            yield return new WaitForSeconds(.01f);
            Destroy(gameObject);
        }

        if(inRoom)
        {
            yield return new WaitForSeconds(.01f);
            Destroy(Spawner);
            Destroy(gameObject);
        }
        
    }

    //checks to see if its takes damage from collisions.
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        { 
            sharpHealth -= 1;
            bleed();
        }
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Explosive"))
        {
            sharpHealth -= 5;
            bleed();
        }
    }

    void FlipLeft()
    {
        transform.localRotation = Quaternion.Euler(0, leftFlipY, 0);
        arm.isRight = false;
    }

    void FlipRight()
    {
        transform.localRotation = Quaternion.Euler(0, rightFlipY, 0);
        arm.isRight = true;
    }

    void Shoot()
    {
        
        Flash.Play();
        gunSounds.Play();
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    void bleed()
    {
         
        Instantiate(Blood, bleedingPoint.position, bleedingPoint.rotation);
        hit.Play();
    }
}
