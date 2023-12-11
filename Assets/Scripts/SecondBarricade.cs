using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBarricade : MonoBehaviour
{
    public static SecondBarricade Instance { get; private set; }
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

    void OpenSecondBarricade()
    {
        //condition is that all other enemies must be dead for the door to disappear
        gameObject.SetActive(false);
        Instantiate(tpose, new Vector3(68.67f, 4.07f, -42.88f), Quaternion.identity);
        Instantiate(tpose, new Vector3(46.82f, 4.07f, -42.88f), Quaternion.identity);
        Instantiate(face, new Vector3(46.82f, 4.07f, -21.6f), Quaternion.identity);
        Instantiate(face, new Vector3(66.55f, 4.07f, -21.6f), Quaternion.identity);
    }

    public void ClearingEnemies()
    {
        progress++;
        if (progress == 6)
        {
            OpenSecondBarricade();
        }
    }
}
