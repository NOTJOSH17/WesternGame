using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
bool facingRight = true;
    public GameObject gun;
    public Transform PivotPoint;
    public GameObject Player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        faceMouse();

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//tracks the players mouse to see if its on the left or right of the player.

        if(mousePos.x < Player.transform.position.x && facingRight)//flips the player right
        {
            Flip();
        }
        if(mousePos.x > Player.transform.position.x && !facingRight)//flips the player left
        {
            Flip();
        }
        
    }

    void faceMouse()//has player face mouse
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - PivotPoint.position.x, mousePosition.y - PivotPoint.position.y);
        PivotPoint.up = direction;
    }




    void Flip()//the main flip script
    {
        facingRight = !facingRight;
        gun.transform.Rotate(0f, 180f, 0f);
    }

    
}
