using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{

    public Text Score;

    // Start is called before the first frame update
    void Start()
    {
        int score = GameManager.Instance.score;
        Score.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
