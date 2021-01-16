using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCntrl : MonoBehaviour
{
     public GameObject player;
    public GameObject bullet;
    public Transform firePoint;
    public AudioSource gunSounds;
    public AudioSource hit;
    public GameObject Blood;
    public Transform bleedingPoint;
    public ParticleSystem Flash;
    public int bossHealth;
    public int maxBossHealth;
    public bool startShooting;
    public bool canShoot;
    public float timer;
    public float startTimer;
    public BossGun arm;
    public TNTSpawner spawnTnT;
    public int shootCounter;
    public int maxShootCounter;
    public HealthSlider healthBar;
    public int hitCounter;

    // Start is called before the first frame update
    void Start()
    {
        timer = startTimer;
        player = GameObject.FindGameObjectWithTag("Player");
        bossHealth = maxBossHealth;
        healthBar.SetMaxHealth(maxBossHealth);
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
            shootCounter +=1;
        }

        if(shootCounter >= maxShootCounter)
        {
            spawnTnT.startTimer = true;
            spawnTnT.isHolding = true;
            startShooting = false;
            timer = startTimer;
        }
        

        //bandits health, if zero, starts death
        if(bossHealth <= 0)
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
        yield return new WaitForSeconds(.01f);
        
        
        Destroy(gameObject);
    }

    //checks to see if its takes damage from collisions.
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        { 
            bossHealth -= 1;
            hitCounter += 1;
            healthBar.SetHealth(bossHealth);
            bleed();
        }
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Explosive"))
        {
            bossHealth -= 5;
            healthBar.SetHealth(bossHealth);
            bleed();
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
        gunSounds.Play();
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    void bleed()
    {
         
        Instantiate(Blood, bleedingPoint.position, bleedingPoint.rotation);
        hit.Play();
    }
}
