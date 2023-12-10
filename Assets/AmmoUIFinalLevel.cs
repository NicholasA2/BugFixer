using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUIFinalLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "Ammo: " + GameManager.Instance.ammo;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Ammo: " + GameManager.Instance.ammo;
    }
}
