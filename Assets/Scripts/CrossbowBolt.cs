using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowBolts : MonoBehaviour
{
    public float speed = 200;
    Vector3 lastPosition;
    RaycastHit[] hitEnemy;
    public GameObject hit;

    void Start()
    {
        Destroy(gameObject, 1);
       // hit = new RaycastHit[1];
    }

    void Update()
    {
        lastPosition = transform.position;
        transform.position += transform.forward * speed * Time.deltaTime;
        CheckHit();
    }

    void CheckHit()
    {
        Ray ray = new Ray(lastPosition, transform.forward);
        float dist = Vector3.Distance(lastPosition, transform.forward);
       // if(Physics.RaycastNonAlloc(ray, hit, dist) > 0)
        //{
        //    Instantiate(hitEnemy, hit[0].point, Quaternion.LookRotation(hit[0].normal));
        //    Destroy(gameObject);
        //}
    }
    
}
