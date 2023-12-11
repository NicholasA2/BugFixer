using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.AddHealingToInventory();
            GameManager.Instance.PickupScore();
            gameObject.SetActive(false);
        }
    }
}
