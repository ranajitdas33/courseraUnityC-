﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages navigation through the menu system
/// </summary>
public static class MenuManager
{
    /// <summary>
    /// Goes to the menu with the given name
    /// </summary>
    /// <param name="name">name of the menu to go to</param>
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Help:

                // go to HelpMenu scene
                SceneManager.LoadScene("HelpMenu");
                break;
            case MenuName.Main:

                // go to MainMenu scene
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Pause:
                
                // instantiate prefab
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;

            case MenuName.Gameover:

                // instantiate prefab
                Object.Instantiate(Resources.Load("GameOver"));
                
                break;

            case MenuName.Win:

                // instantiate prefab
                Object.Instantiate(Resources.Load("Win"));

                break;
        }
    }
}
