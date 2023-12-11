using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBarricade : MonoBehaviour
{
    public static FirstBarricade Instance { get; private set; }
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

    void OpenFirstBarricade()
    {
        //condition is that all other enemies must be dead for the door to disappear
        gameObject.SetActive(false);
        Instantiate(tpose, new Vector3(47.01f, 4.07f, 42.08f), Quaternion.identity);
        Instantiate(face, new Vector3(38.81544f, 4.07f, 42.08f), Quaternion.identity);
        Instantiate(face, new Vector3(51.75f, 4.07f, 42.08f), Quaternion.identity);
    }

    public void ClearingEnemies()
    {
        progress++;
        if (progress == 3)
        {
            OpenFirstBarricade();
        }
    }
}
