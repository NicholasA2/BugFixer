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
            Destroy(gameObject);
            Debug.Log(GameManager.Instance.ammo);
        }
    }
}
