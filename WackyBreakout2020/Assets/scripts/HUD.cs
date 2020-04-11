using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    // scoring support
    [SerializeField]
    Text scoreText;
    int score;

    [SerializeField]
    Text ballsLeftText;
    int ballsLeft = 10;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        scoreText.text = score.ToString();
        ballsLeftText.text = ballsLeft.ToString();
    }

    /// <summary>
    /// Adds the given points to the score
    /// </summary>
    /// <param name="points">points</param>
    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void BallLeft(int leftBall)
    {
        ballsLeft += leftBall;
        ballsLeftText.text = ballsLeft.ToString();
    }


}
