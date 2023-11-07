using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int healingPotions = 1;
    public int ammo = 5;
    public int score = 0;

    void Start()
    {
        
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        
    }

    public void AddHealingToInventory()
    {
        healingPotions++;
    }

    public void AddAmmoToInventory()
    {
        ammo += 5;
    }

    public void PickupScore()
    {
        score += 10;
    }
}
