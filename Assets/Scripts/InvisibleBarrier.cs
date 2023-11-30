using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBarrier : MonoBehaviour
{
    public static InvisibleBarrier Instance { get; private set; }
    public int progress = 0;
    public GameObject face;
    public GameObject tpose;

    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        
    }

    void tutorialComplete()
    {
        gameObject.SetActive(false);
        Instantiate(tpose, new Vector3(34.33f, 1.216f, -105.558f), Quaternion.identity);
        Instantiate(tpose, new Vector3(34.33f, 1.216f, -100.3f), Quaternion.identity);
        Instantiate(tpose, new Vector3(25.3f, 1.216f, -100.87f), Quaternion.identity);
        Instantiate(face, new Vector3(64.92f, 1.216f, -166.42f), Quaternion.identity);
        Instantiate(face, new Vector3(-55.6f, 1.216f, -166.42f), Quaternion.identity);
        Instantiate(face, new Vector3(-37.75f, 1.216f, -159.86f), Quaternion.identity);
        Instantiate(face, new Vector3(-54.99f, 1.216f, -141.7f), Quaternion.identity);
        Instantiate(tpose, new Vector3(4f, 1.216f, -153.42f), Quaternion.identity);
        Instantiate(tpose, new Vector3(3.05f, 1.216f, -149.25f), Quaternion.identity);
        Instantiate(tpose, new Vector3(30.55f, 1.216f, -127.58f), Quaternion.identity);
    }
    
    public void TutorialProgress()
    {
        progress++;
        if(progress >= 4)
        {
            tutorialComplete();
        }
    }
}
