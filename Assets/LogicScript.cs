using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// To get access to UI types add UnityEngine.UI.
using UnityEngine.UI;
// To get the SceneManagement.
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // The player score.
    public int playerScore;
    // The score text.
    public Text scoreText;
    // The game over object.
    public GameObject gameOverScreen;
    // The bird script.
    public BirdScript bird;

    /// <summary>
    /// This is a function that adds a number to the score.
    /// </summary>
    /// <param name="scoreToAdd" type="int" default="1">The amount by which the score needs to be increased.</param>
    /// <returns>void</returns>
    [ContextMenu("Increase Score")]
    public void addToScore(int scoreToAdd = 1)
    {
        // Check if the game is not over.
        if (!bird.gameOver) {
            // Add the given number to the playerscore.
            playerScore += scoreToAdd;
            // Update the text to show to the user what their score is.
            scoreText.text = playerScore.ToString();
        }
    }

    /// <summary>
    /// This is a function that restarts the game.
    /// </summary>
    /// <returns>void</returns>
    public void restartGame()
    {
        // Reload the same scene, since there is only one scene in this game.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// This is a function that sets the game to game over.
    /// </summary>
    /// <returns>void</returns>
    public void gameOver()
    {
        // Show the game over screen.
        gameOverScreen.SetActive(true);
    }
}
