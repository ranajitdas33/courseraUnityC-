using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
    Timer spawnTimer;
    Timer moveTimer;

    BallSpawner spawnBall;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
        // get refrence of componenet
        spawnBall = Camera.main.GetComponent<BallSpawner>();

        //add spawn timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = 10;
        spawnTimer.Run();

        //add move timer
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1;
        moveTimer.Run();
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        // wait for seconds
        if (moveTimer.Finished)
        {
            moveTimer.Stop();
            StartMoving();
        }

        // create new ball and delet previous ball
        if (spawnTimer.Finished)
        {
            spawnBall.SpawnBall();
            Destroy(gameObject);
        }
	}

    /// <summary>
    /// Sets the ball direction to the given direction
    /// </summary>
    /// <param name="direction">direction</param>
    public void SetDirection(Vector2 direction)
    {
        // get current rigidbody speed
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }

    // get the ball moving
    void StartMoving()
    {
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    //void OnBecameInvisible()
    //{
    //    if (!spawnTimer.Finished)
    //    {
    //        Debug.Log("Working");
    //        spawnBall.SpawnBall();
    //    }
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bottom")
        {
            Destroy(gameObject);
            spawnBall.SpawnBall();
        }
    }
}
