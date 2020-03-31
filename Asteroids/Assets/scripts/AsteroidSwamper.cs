using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSwamper : MonoBehaviour {

#region Feilds
    // needed for spawning
    [SerializeField]
    GameObject prefabAsteroid;

    // saved for efficiency
    [SerializeField]
    Sprite asteroidSprite0;
    [SerializeField]
    Sprite asteroidSprite1;
    [SerializeField]
    Sprite asteroidSprite2;


    // spawn control
    const float MinSpawnDelay = 1;
    const float MaxSpawnDelay = 2;

    int asteroidCount;

#endregion

    void Start()
    {
        //initialize asteroid at the start of the game
        SpawnAsteroid();
        
    }

    void SpawnAsteroid()
    {

        // Left edge asteroids position
        Vector3 location = new Vector3(0, 360, -Camera.main.transform.position.z);
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        GameObject asteroid = Instantiate(prefabAsteroid) as GameObject;
        asteroid.transform.position = worldLocation;
        asteroid.GetComponent<Asteroid>().Initialize(Direction.Right);

        // Bottom edge asteroids position
        location = new Vector3(640, 0, -Camera.main.transform.position.z);
        worldLocation = Camera.main.ScreenToWorldPoint(location);
        asteroid = Instantiate(prefabAsteroid) as GameObject;
        asteroid.transform.position = worldLocation;
        asteroid.GetComponent<Asteroid>().Initialize(Direction.Up);

        // Top edge asteroids position
        location = new Vector3(640, 720, -Camera.main.transform.position.z);
        worldLocation = Camera.main.ScreenToWorldPoint(location);
        asteroid = Instantiate(prefabAsteroid) as GameObject;
        asteroid.transform.position = worldLocation;
        asteroid.GetComponent<Asteroid>().Initialize(Direction.Down);

        // Right edge asteroids position
        location = new Vector3(1280, 360, -Camera.main.transform.position.z);
        worldLocation = Camera.main.ScreenToWorldPoint(location);
        asteroid = Instantiate(prefabAsteroid) as GameObject;
        asteroid.transform.position = worldLocation;
        asteroid.GetComponent<Asteroid>().Initialize(Direction.Left);




        // set random sprite for new asteroids
        SpriteRenderer spriteRenderer = asteroid.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            spriteRenderer.sprite = asteroidSprite0;
        }
        else if (spriteNumber == 1)
        {
            spriteRenderer.sprite = asteroidSprite1;
        }
        else if (spriteNumber == 2)
        {
            spriteRenderer.sprite = asteroidSprite2;
        }

       
    }

    
}
