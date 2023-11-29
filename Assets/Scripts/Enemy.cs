using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health = 5f;
    public float speed = 3f;
    private NavMeshAgent nav;
    Transform move;
  

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

    public void ProcessHit(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.enemyAmount -= 1;
        }
    }
}
