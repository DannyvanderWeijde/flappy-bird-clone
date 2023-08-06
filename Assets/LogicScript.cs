using System.Net.Mime;
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
    // The pause screen object.
    public GameObject pauseScreen;
    // Game paused boolean.
    private bool isGamePaused = false;
    // Previous time scale.
    private float previousTimeScale;

    /// <summary>
    /// This is a function that runs code on every frame after being rendered.
    /// </summary>
    void Update()
    {
        // Check if the escape button is pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Check if the game is paused or not and run the correct function after that.
            if (isGamePaused) resumeGame();
            else pauseGame();
        }
    }

    /// <summary>
    /// This is a function that adds a number to the score.
    /// </summary>
    /// <param name="scoreToAdd" type="int" default="1">The amount by which the score needs to be increased.</param>
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
    public void restartGame()
    {
        // Reload the same scene, since there is only one scene in this game.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Resume the game if needed.
        resumeGame();
    }

    /// <summary>
    /// This is a function that sets the game to game over.
    /// </summary>
    public void gameOver()
    {
        // Check if the game over variable is still false, if so set it to true.
        if (!bird.gameOver) bird.gameOver = true;
        // Show the game over screen.
        gameOverScreen.SetActive(true);
    }

    /// <summary>
    /// This is a function that closes the game.
    /// </summary>
    public void closeGame()
    {
        // Close the game.
        Application.Quit();
    }

    /// <summary>
    /// This is a function that resumes the game.
    /// </summary>
    public void resumeGame()
    {
        // Check if the game is paused already.
        if (isGamePaused) {
            // Set game to resume.
            isGamePaused = false;
            // Set the time scale to what it was previously.
            Time.timeScale = previousTimeScale;

            // Hide the pause screen.
            pauseScreen.SetActive(false);
        }
    }

    /// <summary>
    /// This is a function that pauses the game.
    /// </summary>
    private void pauseGame()
    {
        // Check if the game is not over.
        if (!bird.gameOver)
        {
            // Pause the game.
            isGamePaused = true;
            // Save the time scale.
            previousTimeScale = Time.timeScale;
            // Set time scale to 0.
            Time.timeScale = 0f;

            // Show the pause screen.
            pauseScreen.SetActive(true);
        }
    }
}
