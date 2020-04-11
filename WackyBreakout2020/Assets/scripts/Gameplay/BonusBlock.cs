using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : MonoBehaviour {

    HUD hud;

    public int blockPoints = 30;


    /// <summary>
    /// Use this for initialization
    /// </summary>
    virtual protected void Start()
    {
        // save a reference to the hud
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();

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
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            hud.AddPoints(blockPoints);
            Destroy(gameObject);
        }
    }
}
