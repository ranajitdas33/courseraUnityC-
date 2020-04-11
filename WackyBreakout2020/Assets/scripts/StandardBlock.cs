using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// child of block class
/// </summary>
public class StandardBlock : Block
{
    [SerializeField]
    GameObject standardBlockPrefab;

    [SerializeField]
    Sprite standardblock0;

    [SerializeField]
    Sprite standardblock1;

    [SerializeField]
    Sprite standardblock2;

    

    // Use this for initialization
    override protected void Start()
    {
        
    }	
	// Update is called once per frame
	void Update () {
		
	}
}
