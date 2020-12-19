using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    
    public int deathCount;
    public int EnemyAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Death(deathCount);
    }

    void Death(int enemiesDead)
    {
        if(enemiesDead >= EnemyAmount)
        {
            Destroy(gameObject);
        }
    }
}
