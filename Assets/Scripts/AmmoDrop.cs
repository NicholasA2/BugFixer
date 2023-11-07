using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddAmmoToInventory();
            GameManager.Instance.PickupScore();
            Destroy(gameObject);
        }
    }
}
