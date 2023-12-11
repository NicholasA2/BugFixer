using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealingPotions : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Healing Potions: : " + GameManager.Instance.healingPotions;
    }
    void Update()
    {
        text.text = "Healing Potions: : " + GameManager.Instance.healingPotions;
    }
}
