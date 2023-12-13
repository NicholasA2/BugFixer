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
    public int health = 10;
   
    private GameObject[] targets;
    public GameObject gateGameObject;

    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            targets = GameObject.FindGameObjectsWithTag("Target");
            if (gateGameObject == null)
            {
                gateGameObject = GameObject.FindGameObjectWithTag("Gate");
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 5)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    /*
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
    */

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make sure GameManager persists between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Debug.Log("gm score: " + score);
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (AreAllTargetsGreen()) //add condition if all enemies are destroyed
            {
                //Debug.Log("All targets are green!");
                // Check if the gateGameObject has the GateComponent script attached
                GateComponent gateComponent = gateGameObject.GetComponent<GateComponent>();

                if (gateComponent != null && enemyAmount == 0)
                {
                    // Call the Open method on the GateComponent script
                    gateComponent.Open();
                }

            }
            OpenGates();
        }
            
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

    public void TakeDamage()
    {
        health -= 2;
    }
}
