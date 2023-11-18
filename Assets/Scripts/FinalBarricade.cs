using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBarricade : MonoBehaviour
{
    void Update()
    {
        checkForClear();
    }

    void checkForClear()
    {
        //condition is that all other enemies must be dead for the door to disappear
        gameObject.SetActive(false);
    }
}
