using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBarricade : MonoBehaviour
{
    public static FinalBarricade Instance { get; private set; }
    public int progress = 0;
    public GameObject chicken;

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
        Instantiate(chicken, new Vector3(99.19545f, 4.53f, -4.730917f), Quaternion.identity);
    }

    public void ClearingEnemies()
    {
        progress++;
        if (progress == 10)
        {
            OpenFinalBarricade();
        }
    }
}
