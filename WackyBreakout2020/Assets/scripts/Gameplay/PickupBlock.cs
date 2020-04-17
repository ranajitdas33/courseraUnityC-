using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A pickup block
/// </summary>
public class PickupBlock : Block
{
    [SerializeField]
    Sprite freezerSprite;
    [SerializeField]
    Sprite speedupSprite;

    Paddle paddle;
    GameObject paddleObj;

    BallSpawner ball;
    

    PickupEffect effect;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
        paddleObj = GameObject.FindGameObjectWithTag("Paddle");
        paddle = paddleObj.GetComponent<Paddle>();
        ball = Camera.main.GetComponent<BallSpawner>();
        

        // set points
        points = ConfigurationUtils.PickupBlockPoints;
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		
	}

	/// <summary>
    /// Sets the effect for the pickup
    /// </summary>
    /// <value>pickup effect</value>
    public PickupEffect Effect
    {
        set
        {
            effect = value;

            // set sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (effect == PickupEffect.Freezer)
            {
                spriteRenderer.sprite = freezerSprite;
            }
            else
            {
                spriteRenderer.sprite = speedupSprite;
            }
        }
    }

    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (effect == PickupEffect.Freezer)
        {
            paddle.FreezePaddle();
        }
        else if (effect == PickupEffect.Speedup)
        {
            ball.AddBonusSpeed();
        }
    }
}
