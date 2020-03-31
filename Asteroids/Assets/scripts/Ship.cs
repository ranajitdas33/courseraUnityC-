using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A ship
/// </summary>
public class Ship : MonoBehaviour
{
    /// <summary>
    /// Bullet Class
    /// </summary>

    #region Felids

    [SerializeField]
    GameObject prefabExplosion;

    [SerializeField]
    GameObject prefabBullet;

    [SerializeField]
    Text message;

    public HUD hud;

    // fire VFX on pressing space bar
    [SerializeField]
    public ParticleSystem fire;

    // thrust and rotation support
    Rigidbody2D rb2D;
    Vector2 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 10;
    const float RotateDegreesPerSecond = 180;

    

    #endregion

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
	{
		// saved for efficiency
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        // check for rotation input
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0)
        {
            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0) {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            // change thrust direction to match ship rotation
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);
        }

        // shoot bullets
        if (Input.GetKeyDown(KeyCode.E))
        {
            AudioManager.Play(AudioClipName.PlayerShot);
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            Vector2 oldPos = transform.position;
            Vector2 newPos = new Vector2(oldPos.x + 0.64f * Mathf.Cos(zRotation), oldPos.y + 0.64f * Mathf.Sin(zRotation));


            GameObject bullet = Instantiate<GameObject>(prefabBullet, newPos, Quaternion.identity);
            
            bullet.GetComponent<Bullet>().ApplyForce(thrustDirection);
        }

        GameObject asteroid = GameObject.FindWithTag("Asteroids");

        if (asteroid == null)
        {
            hud.StopGameTimer();
            message.text = "You Did it :)";
        }
	}

    /// <summary>
    /// FixedUpdate is called 50 times per second
    /// </summary>
    void FixedUpdate()
    {
        // thrust as appropriate
        if (Input.GetAxis("Thrust") != 0)
        {
            AudioManager.Play(AudioClipName.Thrust);
            rb2D.AddForce(ThrustForce * thrustDirection, ForceMode2D.Force);
            fire.Emit(1);           // fire VFX
        }
    }

    // On collision with asteroid
    void OnCollisionEnter2D(Collision2D col)
    {
        hud.StopGameTimer();
        message.text = "Game Over :(";
        AudioManager.Play(AudioClipName.PlayerDeath);
        Destroy(gameObject);
        Instantiate<GameObject>(prefabExplosion, transform.position, Quaternion.identity);
    }
}
