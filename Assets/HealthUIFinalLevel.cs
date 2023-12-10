using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIFinalLevel : MonoBehaviour
{
    public Text thisText;
    // Start is called before the first frame update
    void Start()
    {
       thisText = GetComponent<Text>();
       thisText.text = "Health: " + GameManager.Instance.health;
    }

    // Update is called once per frame
    void Update()
    {
        thisText.text = "Health: " + GameManager.Instance.health;
    }
}
