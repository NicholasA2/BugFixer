using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public GameObject boltPrefab;
    public Transform spawnPoint;
    public float boltSpeed = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBolt();
        }
    }

    void ShootBolt()
    {
        if (boltPrefab != null && spawnPoint != null)
        {
            GameObject newBolt = Instantiate(boltPrefab, spawnPoint.position, spawnPoint.rotation);

            // Get the Rigidbody component of the bolt if it has one
            Rigidbody boltRigidbody = newBolt.GetComponent<Rigidbody>();

            if (boltRigidbody != null)
            {
                // Apply forward force to the bolt to simulate a ranged attack
                boltRigidbody.velocity = spawnPoint.forward * boltSpeed;
            }
            else
            {
                Debug.LogError("The boltPrefab does not have a Rigidbody component.");
            }
        }
        else
        {
            Debug.LogError("boltPrefab or spawnPoint not assigned.");
        }
    }
}
