using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public ParticleSystem bulletHitEffect;
    void Start()
    {
        bulletHitEffect.Play();
        StartCoroutine(timer());
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
