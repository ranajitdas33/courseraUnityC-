using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A block
/// </summary>
public class Block : IntEventInvoker
{
    protected int points;
    private AddPointsAddedListener unityEvent;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        unityEvent = new AddPointsAddedListener();
        EventManager.AddInvoker(EventName.PointsAddedEvent, this);
        //EventManager.AddListener(EventName.PointsAddedEvent, AddPointsAddedListener);
    }

    private void AddPointsAddedListener(int arg0)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// Destroys the block on collision with a ball
    /// </summary>
    /// <param name="coll">Coll.</param>
    virtual protected void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            AudioManager.Play(AudioClipName.BlockHit);
            HUD.AddPoints(points);
            Destroy(gameObject);
        }
    }
}
