using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Listens for the OnClick events for the main menu buttons
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Handles the on click event from the play button
    /// </summary>
    public void HandlePlayButtonOnClickEvent()
    {
        SceneManager.LoadScene("gameplay");
        Time.timeScale = 1;
    }

    // help menu
    public void HandleHelpButtonOnClickEvent()
    {
        // load help menu
        MenuManager.GoToMenu(MenuName.Help);
    }

    // pause 
    public void HandlePauseButtonOnClickEvent()
    {
        // unpause game and destroy menu
        Time.timeScale = 0;
        MenuManager.GoToMenu(MenuName.Pause);
    }

    /// <summary>
    /// Handles the on click event from the quit button
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }
}
