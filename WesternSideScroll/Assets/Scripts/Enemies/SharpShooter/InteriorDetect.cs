using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorDetect : MonoBehaviour
{
    public GameObject Spawner;
    public Transform rayPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayPosition.position, rayPosition.TransformDirection(Vector2.down), .5f);
        Debug.DrawRay(rayPosition.position, rayPosition.TransformDirection(Vector2.down) * .5f, Color.red);
        
        if(hit.collider.tag != "Bandit")
        {
            Debug.Log("DESTROY");
            Destroy(Spawner);
        }
        else if (hit.collider.tag == "Bandit")
        {
            return;
        }
    }
}
