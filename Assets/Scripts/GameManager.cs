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
    public int boss = 1;
   
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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make sure GameManager persists between scenes
        }
        else
        {
            // If the GameManager is in a scene where it should not persist, destroy it
            if (SceneManager.GetActiveScene().buildIndex != 1)
            {
                Destroy(gameObject);
            }
            else
            {
                // If the GameManager is in the game scene, update references and ensure it persists
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }


    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (AreAllTargetsGreen()) //add condition if all enemies are destroyed
            {
                // Check if the gateGameObject has the GateComponent script attached
                GateComponent gateComponent = gateGameObject.GetComponent<GateComponent>();

                if (gateComponent != null && enemyAmount == 0)
                {
                    // Call the Open method on the GateComponent script
                    gateComponent.Open();
                }

            }
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

    public void TakeDamage()
    {
        health -= 2;
    }

    public void ResetGameManager()
    {
        healingPotions = 1;
        ammo = 5;
        score = 0;
        enemyAmount = 10;
        health = 10;
        boss = 1;

        targets = null;
        gateGameObject = null;

        InvisibleBarrier.Instance.progress = 0;
        Start();
        Awake();

        // Load the scene asynchronously
        SceneManager.LoadScene(1);    
    }
}
