using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    [SerializeField]
    Text ScoreTimeText;

    [SerializeField]
    Text message;

    float currentTime = 0;
    bool gameTimer = true;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameTimer == true)
        {
            currentTime += 1 * Time.deltaTime;

            ScoreTimeText.text = currentTime.ToString("0");

        }
        
        
        
	}

    public void StopGameTimer()
    {
        gameTimer = false;
    }
}
