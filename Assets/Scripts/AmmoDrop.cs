using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.AddAmmoToInventory();
            GameManager.Instance.PickupScore();
            gameObject.SetActive(false);
        }
    }
}
