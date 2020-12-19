using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDetector : MonoBehaviour
{

    public LayerMask player;
    public BoxCollider2D jumpDetector;
    public PlayerCntrl playerController;
    public LayerMask nonJump;
    public bool ifGrounded;

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
        }
        else
        {
            playerController.canJump = false;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(jumpDetector.bounds.center, jumpDetector.bounds.size, 0f, Vector2.down, .1f, nonJump, ~player);
        return hit.collider != null;
    }
}
