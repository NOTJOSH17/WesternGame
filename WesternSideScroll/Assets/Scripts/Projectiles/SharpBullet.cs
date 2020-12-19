using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpBullet : MonoBehaviour
{

     public float speed;
    private Rigidbody2D rigi;
    public AudioSource ricochet;
    public GameObject hitEffect;
    public Transform hitPoint;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        rigi.velocity = transform.up * speed;
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1.7f);

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.gameObject.layer == LayerMask.NameToLayer("Bounce"))
        {
            SummonHitEffect();
            Destroy(gameObject);
        }if(other.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        }

    }
    void SummonHitEffect()
    {
        Instantiate(hitEffect, hitPoint.position, hitPoint.rotation);
    }
}
