using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveRange : MonoBehaviour
{
    public GameObject explosionEffect;
    public GameObject player;
    
    public LayerMask playerLayer;
    public LayerMask explosiveLayer;
    public LayerMask ignoreLayer;
    public PlayerCntrl playerControl;
    public CircleCollider2D blastRange;
    public int DMG;
    public List<GameObject> canExplode = new List<GameObject>();
    int canExplodeSize;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerMain");
        playerControl = player.GetComponent<PlayerCntrl>();
        StartCoroutine(timer());

        canExplodeSize = canExplode.Count;
        
    }

    private void Update()
    {
        if(PlayerTouch())
        {
            playerControl.health -= DMG;
            Destroy(gameObject);
        }

        if(ObjectTouch())
        {
            Debug.Log("Test");
        }
        
    }

    IEnumerator timer()
    {
        BlowupEffect();
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }

    private bool PlayerTouch()
    {
        RaycastHit2D hit = Physics2D.CircleCast(blastRange.bounds.center, blastRange.radius, Vector2.down, .1f, playerLayer);//gets the players layer. could make a boss layer to do the same thing.
        return hit.collider != null;
    }

    private bool ObjectTouch()
    {
        RaycastHit2D hit = Physics2D.CircleCast(blastRange.bounds.center, blastRange.radius, Vector2.down, .1f, explosiveLayer, ~ignoreLayer);//gets the players layer. could make a boss layer to do the same thing.
        canExplode.Add(hit.collider.gameObject);
        foreach(GameObject g in canExplode)
        {   
            Destroy(g);
        }
        return hit.collider != null;
    }



    void BlowupEffect()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.Euler(0,0,0));
    }
}
