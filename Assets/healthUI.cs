using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "Health: " + GameManager.Instance.health;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Health: " + GameManager.Instance.health;
    }
}
