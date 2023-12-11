using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreScript : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + GameManager.Instance.score;
    }
}
