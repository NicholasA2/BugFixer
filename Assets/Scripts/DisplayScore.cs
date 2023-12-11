using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Final Score: " + GameManager.Instance.score;
    }
    void Update()
    {
        text.text = "Final Score: " + GameManager.Instance.score;
    }
}
