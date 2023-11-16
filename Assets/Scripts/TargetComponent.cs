using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetComponent : MonoBehaviour
{
    // Reference to the target's renderer component
    private Renderer targetRenderer;

    void Start()
    {
        // Get the Renderer component of the target
        targetRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ammo")
        {
            targetRenderer.material.color = Color.green;
        }
    }

    public Color GetColor()
    {
        return targetRenderer.material.color;
    }
}
