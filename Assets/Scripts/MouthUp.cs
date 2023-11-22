using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthUp : MonoBehaviour
{
    public Vector3 Float = new Vector3(0, 0.5f, 0);

    void Start()
    {
        InvokeRepeating("upAndDown", 0f, 0.5f);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += (Float * Time.deltaTime);
    }

    void upAndDown()
    {
        Float *= -1;
    }
}
