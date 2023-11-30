using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public float rotationSpeed = 800f; // Adjust the speed as needed
    private bool isAttacking = false;

    public AudioClip swordHitClip; // Assign your sword hit sound in the Unity Editor
    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component to this GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = swordHitClip;
        audioSource.playOnAwake = false; // Ensure the sound doesn't play automatically on startup
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isAttacking)
        {
            // Trigger attack animation or movement
            StartCoroutine(Attack());
            audioSource.Play();
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;

        // Play your sword attack animation here if you have one

        float attackDuration = 0.2f; // Adjust the duration as needed

        // Rotate the sword forward (downward) during the attack
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = initialRotation * Quaternion.Euler(90f, 0f, 0f); // Rotate around the x-axis by 90 degrees

        float elapsedTime = 0f;

        while (elapsedTime < attackDuration)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / attackDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset the sword rotation
        transform.rotation = initialRotation;

        isAttacking = false;
    }
}