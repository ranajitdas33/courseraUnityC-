using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;

    Timer randomTimer;

    bool retrySpawn = false;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    // Start is called before the first frame update
    void Start()
    {
        RandomTimer();

        GameObject tempBall = Instantiate<GameObject>(ballPrefab);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfWidth,
            tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);
    }

    // Update is called once per frame
    void Update()
    {
        if (randomTimer.Finished)
        {
            SpawnBall();
            randomTimer.Run();
        }

        if (retrySpawn == true)
        {
            SpawnBall();
        }
    }

    // creat a new ball
    public void SpawnBall()
    {
        //Instantiate(ballPrefab);

        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            retrySpawn = false;
            Vector2 pos = new Vector2(Random.Range(-4.5f, 4.5f), Random.Range(-1.5f, 1.5f));
            Instantiate(ballPrefab, pos, Quaternion.identity);
        }
        else
        {
            retrySpawn = true;
        }
    }

    void RandomTimer()
    {
        randomTimer = gameObject.AddComponent<Timer>();
        float randomValue = Random.Range(ConfigurationUtils.MinSpawnTime, ConfigurationUtils.MaxSpawnTime);
        randomTimer.Duration = randomValue;
        randomTimer.Run();
    }

}
