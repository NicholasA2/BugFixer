using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public float rotationSpeed = 2.0f;
    float rotationY = 0;
    float rotationX = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        rotationX += mouseY * Time.deltaTime * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX,-45f,45f);
        transform.rotation = Quaternion.Euler(rotationX,0.0f, 0.0f);
    }
}
