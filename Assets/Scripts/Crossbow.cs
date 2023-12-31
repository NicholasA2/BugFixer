using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public GameObject boltPrefab;
    public Transform spawnPoint;
    public float boltSpeed = 20f;
    public float shootForce = 10f;
    public AudioSource source;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ShootBolt();
        }
    }

    void ShootBolt()
    {
        if (GameManager.Instance.ammo > 0)
        {
            if (boltPrefab != null && spawnPoint != null)
            {
                GameObject newBolt = Instantiate(boltPrefab, spawnPoint.position, spawnPoint.rotation);

                Vector3 shootDirection = spawnPoint.forward;
                newBolt.transform.position += shootDirection * shootForce * Time.deltaTime;



                // Get the Rigidbody component of the bolt if it has one
                Rigidbody boltRigidbody = newBolt.GetComponent<Rigidbody>();

                if (boltRigidbody != null)
                {
                    // Apply forward force to the bolt to simulate a ranged attack
                    boltRigidbody.velocity = spawnPoint.forward * boltSpeed;
                    GameManager.Instance.ammo--;
                    source.Play();
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
}
