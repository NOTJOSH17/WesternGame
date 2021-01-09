using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTRoller : MonoBehaviour
{
    public Rigidbody2D rigi;
    public BoxCollider2D groundDetector;
    public LayerMask nonJump;
    public LayerMask player;
    public TNTCnrtl TntControl;
    public CircleCollider2D circCold;
    public GameObject tntSpawner;
    public TNTSpawner spawnerScript;
    public float gravity;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        TntControl = GetComponent<TNTCnrtl>();
        tntSpawner = GameObject.FindGameObjectWithTag("TnTSpawner");
        spawnerScript = tntSpawner.GetComponent<TNTSpawner>();
        gravity = rigi.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {   
        if(spawnerScript.isHolding == true)
        {
            rigi.velocity = transform.up * 0f;
            rigi.gravityScale = 0f;
        }
        else
        {
            anim.SetBool("isRoll", true);
            StartCoroutine(TntDestroy());
            rigi.gravityScale = gravity;

            if(!isGrounded())
            {
                rigi.velocity = transform.up * 1f;
            }
            else
            {
                rigi.velocity = transform.up * 3f;
            }
        }
        
        
        

        if(PlayerTouch())
        {
            TntControl.Explosion();
        }
    }

    IEnumerator TntDestroy()
    {
        yield return new WaitForSeconds(2f);
        TntControl.Explosion();
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(groundDetector.bounds.center, groundDetector.bounds.size, 0f, Vector2.down, .1f, nonJump, ~player);
        return hit.collider != null;
    }
    private bool PlayerTouch()
    {
        RaycastHit2D hit = Physics2D.CircleCast(circCold.bounds.center, circCold.radius, Vector2.down, .1f, player);
        return hit.collider != null;
    }
}
