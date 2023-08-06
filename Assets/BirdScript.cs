using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // The rigid body of the bird.
    public Rigidbody2D myRigidBody;
    // The flap strength of the bird.
    public float flapStrength = 15;
    // The logic script.
    public LogicScript logic;
    // The state of the game over.
    public bool gameOver = false;

    /// <summary>
    /// This is a function that runs code on every frame after being rendered.
    /// </summary>
    void Update()
    {
        // Check the game over state.
        checkGameOverState();
        // Check the space bar press.
        checkSpaceBarPress();
    }

    /// <summary>
    /// This is a function that runs when the bird hits something.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Show the game over screen.
        logic.gameOver();
        // Set the game to game over.
        gameOver = true;
    }

    /// <summary>
    /// This is a function that checks the game over state of the game.
    /// </summary>
    private void checkGameOverState()
    {
        // Check if the bird is out of the screen.
        if (transform.position.y < -17 || transform.position.y > 17)
        {
            // If so set the game to game over.
            logic.gameOver();
        }
    }

    /// <summary>
    /// This is a function that checks if the space bar has been pressed.
    /// </summary>
    private void checkSpaceBarPress()
    {
        // Check if the users has pressed the space bar.
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            /*
             * Change the velocity of the bird so it flies up.
             * We use the flapStrength property to calculate by how much the bird should fly up.
             */
            myRigidBody.velocity = Vector2.up * flapStrength;
        }
    }
}
