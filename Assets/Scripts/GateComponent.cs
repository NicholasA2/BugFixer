using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateComponent : MonoBehaviour
{
    // Rotation speed when opening the gate
    public float rotationSpeed = 30f;

    // Flag to check if the gate is currently opening
    private bool isOpening = false;

    // Flag to check if the gate is already open
    private bool isOpen = false;

    // Method to open the gate
    public void Open()
    {
        if (!isOpening && !isOpen)
        {
            StartCoroutine(OpenCoroutine());
        }
    }

    // Coroutine to smoothly open the gate
    private IEnumerator OpenCoroutine()
    {
        isOpening = true;

        float initialRotation = transform.rotation.eulerAngles.y;
        float targetRotation = initialRotation + 90f;

        while (transform.rotation.eulerAngles.y < targetRotation)
        {
            float newRotation = Mathf.MoveTowards(transform.rotation.eulerAngles.y, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, newRotation, transform.rotation.eulerAngles.z);

            yield return null;
        }

        isOpen = true; // Set the gate to be open
        isOpening = false;
    }
}
