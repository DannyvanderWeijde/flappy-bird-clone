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
    /// This is a function that runs code on class  when its rendered for the first time.
    /// </summary>
    /// <returns>void</returns>
    void Start()
    {
        
    }

    /// <summary>
    /// This is a function that runs code on every frame after being rendered.
    /// </summary>
    /// <returns>void</returns>
    void Update()
    {
        // Check if the bird is out of the screen.
        if (transform.position.y < -17 || transform.position.y > 17)
        {
            // If so set the game to game over.
            logic.gameOver();
        }

        // Check if the users has pressed the spacebar.
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            /*
             * Change the velocity of the bird so it flies up.
             * We use the flapStrength property to calculate by how much the bird should fly up.
             */
            myRigidBody.velocity = Vector2.up * flapStrength;
        }
    }

    /// <summary>
    /// This is a function that runs when the bird hits something.
    /// </summary>
    /// <returns>void</returns>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Show the game over screen.
        logic.gameOver();
        // Set the game to game over.
        gameOver = true;
    }
}
