using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To get the SceneManagement.
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    // The logic script.
    private LogicScript logicScript;

    /// <summary>
    /// This is a function that runs code on class  when its rendered for the first time.
    /// </summary>
    void Start()
    {
        // Get the pipe spawner.
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    /// <summary>
    /// This is a function loads a scene.
    /// </summary>
    /// <param name="sceneName" type="string">The name of the scene that needs to be loaded.</param>
    /// <returns>void</returns>
    public void loadScene(string sceneName)
    {
        // Reload the same scene, since there is only one scene in this game.
        SceneManager.LoadScene(sceneName);
        // Resume the game if it is paused.
        logicScript.resumeGame();
    }
}
