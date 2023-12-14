using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Throne")
        {
            if (GameManager.Instance.boss == 0)
            {
                SceneManager.LoadScene(5);
            }
        }
    }
}
