using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float health = 5f;
    public float speed = 3f;
    private NavMeshAgent nav;
    Transform move;
    public AudioSource source;
    public Transform blood;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            move = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        nav.destination = move.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ammo")
        {
            ProcessHit(1);
        }
        if(other.gameObject.tag == "Player")
        {
            GameManager.Instance.TakeDamage();
        }
    }

    public void ProcessHit(float damage)
    {
        health -= damage;
        source.Play();
        if (blood)
        {
            GameObject ouch = ((Transform)Instantiate(blood, this.transform.position, this.transform.rotation)).gameObject;
            Destroy(ouch, 2.0f);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.enemyAmount -= 1;
            if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                FirstBarricade.Instance.ClearingEnemies();
                SecondBarricade.Instance.ClearingEnemies();
                FinalBarricade.Instance.ClearingEnemies();
            }
        }
    }
}
