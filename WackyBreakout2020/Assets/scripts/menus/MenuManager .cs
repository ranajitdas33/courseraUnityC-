using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    // go to menu with the given name
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Main:

                // go to MainMenu scene
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Pause:

                // instantiate prefab
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;

            case MenuName.Help:

                // instantiate prefab
                Object.Instantiate(Resources.Load("HelpMenu"));
                break;
        }
    }
}
