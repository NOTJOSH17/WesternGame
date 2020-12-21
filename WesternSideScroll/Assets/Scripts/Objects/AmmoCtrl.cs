using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCtrl : MonoBehaviour
{
    public GameObject playerController;

    private void OnTriggerStay2D(Collider2D other) {
        playerController = other.gameObject;
        other = other.GetComponent<Collider2D>();
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(playerController.GetComponent<PlayerCntrl>().needReload == true || playerController.GetComponent<PlayerCntrl>().clipCount <= playerController.GetComponent<PlayerCntrl>().maxClipCount -1)
            {
                playerController.GetComponent<PlayerCntrl>().bulletCount = playerController.GetComponent<PlayerCntrl>().maxBulletCount;
                playerController.GetComponent<PlayerCntrl>().clipCount = playerController.GetComponent<PlayerCntrl>().maxClipCount;
                Destroy(gameObject);
            }

        }
    }

}
