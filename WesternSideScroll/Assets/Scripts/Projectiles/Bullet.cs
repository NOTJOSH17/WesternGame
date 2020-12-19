using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rigi;
    Vector3 lastVelocity;
    int bounceCount;
    public AudioSource ricochet;
    public GameObject hitEffect;
    public Transform hitPoint;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        rigi.velocity = transform.up * speed;
        StartCoroutine(timer());
        bounceCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        lastVelocity = rigi.velocity;

        if(bounceCount == 4)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(1.7f);

        Destroy(gameObject);
    }
    

    void OnCollisionEnter2D(Collision2D other) 
    {
        
        
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Bounce"))
        {
            ricochet.Play();
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized / .76f, other.contacts[0].normal);

            rigi.velocity = direction * Mathf.Max(speed, 0f);
            
            bounceCount +=1;

            SummonHitEffect();

        }
        
        else if (other.collider.gameObject.layer == LayerMask.NameToLayer("BulletHit"))
        {
           Destroy(gameObject);
        }
        else
        {
            rigi.velocity = new Vector3(0,0,0);
            Destroy(gameObject);
        }
    }

    void SummonHitEffect()
    {
        Instantiate(hitEffect, hitPoint.position, hitPoint.rotation);
    }
}
