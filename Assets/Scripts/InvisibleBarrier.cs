using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBarrier : MonoBehaviour
{
    public static InvisibleBarrier Instance { get; private set; }
    public int progress = 0;

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        
    }

    void tutorialComplete()
    {
        gameObject.SetActive(false);
    }
    
    public void TutorialProgress()
    {
        progress++;
        if(progress >= 4)
        {
            tutorialComplete();
        }
    }
}
