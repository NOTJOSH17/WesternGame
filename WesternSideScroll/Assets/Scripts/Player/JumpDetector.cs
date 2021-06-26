using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDetector : MonoBehaviour
{

    public LayerMask player;
    public BoxCollider2D jumpDetector;
    public PlayerCntrl playerController;
    public LayerMask nonJump;
    public LayerMask ladderMask;
    public bool ifGrounded;
    public Animator HatAnim;

    // Start is called before the first frame update
    void Start()
    {
        jumpDetector = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded())
        {
            playerController.canJump = true;
            //HatAnim.Play("HatLand");
        }
        else
        {
            playerController.canJump = false;
            //HatAnim.Play("HatJump");
        }

        if(isClimb())
        {
            playerController.canJump = false;
            //HatAnim.SetBool("IsMoving", true);
           //HatAnim.Play("HatIdle");
            //HatAnim.enabled = false;
        }
        else
        {
            //HatAnim.enabled = true;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(jumpDetector.bounds.center, jumpDetector.bounds.size, 0f, Vector2.down, .1f, nonJump, ~player);
        return hit.collider != null;
    }

    private bool isClimb()
    {
        RaycastHit2D hit = Physics2D.BoxCast(jumpDetector.bounds.center, jumpDetector.bounds.size, 0f, Vector2.down, .1f, ladderMask, ~player);
        return hit.collider != null;
    }

}
