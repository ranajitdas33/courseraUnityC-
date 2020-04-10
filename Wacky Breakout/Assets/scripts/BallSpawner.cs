using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // creat a new ball
    public void SpawnBall()
    {
        Instantiate(ballPrefab);
        Debug.Log("Ball 2");
    }
}
