using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int healingPotions = 1;
    public int ammo = 5;
    public int score = 0;
    public int enemyAmount = 10;
   
    private GameObject[] targets;
    public GameObject gateGameObject;

    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");
        if (gateGameObject == null)
        {
            gateGameObject = GameObject.FindGameObjectWithTag("Gate");
        }
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
        if (AreAllTargetsGreen()) //add condition if all enemies are destroyed
        {
            Debug.Log("All targets are green!");
            // Check if the gateGameObject has the GateComponent script attached
            GateComponent gateComponent = gateGameObject.GetComponent<GateComponent>();

            if (gateComponent != null)
            {
                // Call the Open method on the GateComponent script
                gateComponent.Open();
            }

        }
        OpenGates();
    }

 
    private bool AreAllTargetsGreen()
    {
        foreach (GameObject target in targets)
        {
            TargetComponent targetComponent = target.GetComponent<TargetComponent>();
            if (targetComponent != null)
            {
                if (targetComponent.GetColor() != Color.green)
                {
                    return false; // At least one target is not green
                }
            }
        }

        return true; 
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

    public void OpenGates()
    {
        if(enemyAmount == 0)
        {
            //destroy barrier
        }
    }
}
