using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public Transform firePoint;
    public AudioSource gunSounds;
    public AudioSource hit;
    public GameObject Blood;
    public Transform bleedingPoint;
    public ParticleSystem Flash;
    int bandHealth;
    public bool startShooting;
    public bool canShoot;
    public float timer;
    public float startTimer;
    public GunFacePlayer arm;
    public GameObject BossStartPoint;

    // Start is called before the first frame update
    void Start()
    {
        timer = startTimer;
        bandHealth = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        BossStartPoint = GameObject.FindGameObjectWithTag("BossSpawnPoint");
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
        if(bandHealth <= 0)
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

        if(player.transform.position.x >= BossStartPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator death()
    { 
        yield return new WaitForSeconds(.01f);    
        hit.Play(); 
        bleed();
        Destroy(gameObject);
    }

    //checks to see if its takes damage from collisions.
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        { 
            bandHealth -= 1;
        }
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Explosive"))
        {
            bandHealth -= 1;
        }
    }

    void FlipLeft()
    {
        transform.localRotation = Quaternion.Euler(0, 180, 0);
        arm.isRight = false;
    }

    void FlipRight()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        arm.isRight = true;
    }

    void Shoot()
    {
        Flash.Play();
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        gunSounds.Play();
    }

    void bleed()
    {
        Instantiate(Blood, bleedingPoint.position, bleedingPoint.rotation);
    }
}
