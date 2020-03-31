using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    const float bulletForce = 500f;
    const float bulletLifeSpan = 2f;
    Timer deathTimer;

    void Start()
    {
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = bulletLifeSpan;
        deathTimer.Run();
    }

    void Update()
    {
       // destroy bullet over time
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
    }

    // apply force to the bullet
    public void ApplyForce(Vector2 thrustDirection)
    {
        GetComponent<Rigidbody2D>().AddForce(bulletForce * thrustDirection, ForceMode2D.Force);
    }
}
