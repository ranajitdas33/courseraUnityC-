using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
    // move delay timer
    Timer moveTimer;

    // death timer
    Timer deathTimer;

    Rigidbody2D rb2d;

    Timer speedUpTimer;
    bool isSpeeding = false;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
	{
        //rb2d = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
        rb2d = GetComponent<Rigidbody2D>();
        // start move timer
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1;
        moveTimer.Run();

        // start death timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeSeconds;
        deathTimer.Run();

        speedUpTimer = gameObject.AddComponent<Timer>();
        speedUpTimer.Duration = ConfigurationUtils.SpeedUpEffectDuration;

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
	{
        // move when time is up
        if (moveTimer.Finished)
        {
            moveTimer.Stop();
            StartMoving();
            Time.timeScale = 1;
            //AddBonusSpeed();
        }

		// die when time is up
        if (deathTimer.Finished)
        {
            // spawn new ball and destroy self
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }

        if (speedUpTimer.Finished && isSpeeding)
        {
            Time.timeScale = 1;
            rb2d.velocity /= 2;
            isSpeeding = false;
        }
    }

    /// <summary>
    /// Spawn new ball and destroy self when out of game
    /// </summary>
    void OnBecameInvisible()
    {
        // death timer destruction is in Update
        if (!deathTimer.Finished)
        {
            // only spawn a new ball if below screen
            float halfColliderHeight = 
                gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            if (transform.position.y - halfColliderHeight < ScreenUtils.ScreenBottom)
            {
                Camera.main.GetComponent<BallSpawner>().SpawnBall();
                HUD.ReduceBallsLeft();
            }
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Starts the ball moving
    /// </summary>
    void StartMoving()
    {
        // get the ball moving
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        rb2d.AddForce(force);
    }

    /// <summary>
    /// Sets the ball direction to the given direction
    /// </summary>
    /// <param name="direction">direction</param>
    public void SetDirection(Vector2 direction)
    {
        // get current rigidbody speed
        //Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }

    public void AddBonusSpeed()
    {
        Debug.Log("ADD SPEED");

        // if ball already has bonus speed
        if (isSpeeding)
        {
            Debug.Log("IF");
            //rb2d.velocity *= 7;
            //isSpeeding = true;
            //speedUpTimer.Run();
            Time.timeScale = 1;
            speedUpTimer.AddTime(ConfigurationUtils.SpeedUpEffectDuration);
        }
        // if the timer hasn't started and the balls not speeding

        else if (speedUpTimer !=null && !isSpeeding && !speedUpTimer.Running)
        {
            Debug.Log("ELSE");
            Time.timeScale = 3;
            rb2d.velocity *= 2;
            isSpeeding = true;
            speedUpTimer.Run();
        }
    }
}