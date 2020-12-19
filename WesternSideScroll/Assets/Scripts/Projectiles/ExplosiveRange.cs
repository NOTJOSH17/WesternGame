using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveRange : MonoBehaviour
{
    public GameObject explosionEffect;

    void Start()
    {
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        BlowupEffect();
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }

    void BlowupEffect()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.Euler(0,0,0));
    }
}
