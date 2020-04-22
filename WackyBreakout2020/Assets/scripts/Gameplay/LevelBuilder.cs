﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Builds a level
/// </summary>
public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject prefabPaddle;

    [SerializeField]
    GameObject prefabStandardBlock;
    [SerializeField]
    GameObject prefabBonusBlock;
    [SerializeField]
    GameObject prefabPickupBlock;


    public static int blockCountInScene;

    

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        //wackyBreakoutScript = Camera.main.GetComponent<WackyBreakout>().enabled = true;
        //finalScoreActivate = GameObject.FindGameObjectWithTag("Final").SetActive(false);

        //finalScoreActivate = Object.Find<Text>("FinalScore");
        Instantiate(prefabPaddle);

        // retrieve block size
        GameObject tempBlock = Instantiate<GameObject>(prefabStandardBlock);
        BoxCollider2D collider = tempBlock.GetComponent<BoxCollider2D>();
        float blockWidth = collider.size.x;
        float blockHeight = collider.size.y;
        Destroy(tempBlock);

        // calculate blocks per row and make sure left block position centers row
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        int blocksPerRow = (int)(screenWidth / blockWidth);
        float totalBlockWidth = blocksPerRow * blockWidth;
        float leftBlockOffset = ScreenUtils.ScreenLeft +
            (screenWidth - totalBlockWidth) / 2 +
            blockWidth / 2;

        float topRowOffset = ScreenUtils.ScreenTop -
            (ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom) / 5 -
            blockHeight / 2;

        // add rows of blocks
        Vector2 currentPosition = new Vector2(leftBlockOffset, topRowOffset);
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < blocksPerRow; column++)
            {
                PlaceBlock(currentPosition);
                currentPosition.x += blockWidth;
            }

            // move to next row
            currentPosition.x = leftBlockOffset;
            currentPosition.y += blockHeight;
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // end game when last block is destroyed
        blockCountInScene = GameObject.FindGameObjectsWithTag("Block").Length;

        if (blockCountInScene == 0)
        {
            MenuManager.GoToMenu(MenuName.Win);

            Camera.main.GetComponent<LevelBuilder>().enabled = false;
        }

        // stop the pause menu prefab from instantiating
        if (Time.timeScale == 0)
        {            
            Camera.main.GetComponent<WackyBreakout>().enabled = false;
        }

        if (GameObject.FindGameObjectWithTag("Finish") != null)
        {
            GameObject.FindGameObjectWithTag("Final").SetActive(true);
        }
    }


    /// <summary>
    /// Places a randomly-selected block at the given position
    /// </summary>
    /// <param name="position">position of the block</param>
    void PlaceBlock(Vector2 position)
    {
        float randomBlockType = Random.value;
        if (randomBlockType < ConfigurationUtils.StandardBlockProbability)
        {
            Instantiate(prefabStandardBlock, position, Quaternion.identity);
        }
        else if (randomBlockType <
            (ConfigurationUtils.StandardBlockProbability + ConfigurationUtils.BonusBlockProbability))
        {
            Instantiate(prefabBonusBlock, position, Quaternion.identity);
        }
        else
        {
            // pickup block selected
            GameObject pickupBlock = Instantiate(prefabPickupBlock, position, Quaternion.identity);
            PickupBlock pickupBlockScript = pickupBlock.GetComponent<PickupBlock>();

            // set pickup effect
            float freezerThreshold = ConfigurationUtils.StandardBlockProbability +
                ConfigurationUtils.BonusBlockProbability +
                ConfigurationUtils.FreezerBlockProbability;
            if (randomBlockType < freezerThreshold)
            {
                pickupBlockScript.Effect = PickupEffect.Freezer;
            }
            else
            {
                pickupBlockScript.Effect = PickupEffect.Speedup;
            }
        }
    }
}
