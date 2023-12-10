using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBarricade : MonoBehaviour
{
    public static FinalBarricade Instance { get; private set; }
    public int progress = 0;
    public GameObject face;
    public GameObject tpose;

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        
    }

    void OpenFinalBarricade()
    {
        //condition is that all other enemies must be dead for the door to disappear
        gameObject.SetActive(false);
    }

    public void ClearingEnemies()
    {
        progress++;
        if (progress >= 10)
        {
            OpenFinalBarricade();
        }
    }
}
