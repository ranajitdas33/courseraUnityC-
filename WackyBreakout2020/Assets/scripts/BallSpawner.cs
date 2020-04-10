using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;

    Timer randomTimer;

    // Start is called before the first frame update
    void Start()
    {
        RandomTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (randomTimer.Finished)
        {
            SpawnBall();
            randomTimer.Run();
        }
    }

    // creat a new ball
    public void SpawnBall()
    {
        Instantiate(ballPrefab);
    }

    void RandomTimer()
    {
        randomTimer = gameObject.AddComponent<Timer>();
        float randomValue = Random.Range(ConfigurationUtils.MinSpawnTime, ConfigurationUtils.MaxSpawnTime);
        randomTimer.Duration = randomValue;
        randomTimer.Run();
    }
}
