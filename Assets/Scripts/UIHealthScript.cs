using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthScript : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Health: 10";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Health: " + GameManager.Instance.health;
    }
}
