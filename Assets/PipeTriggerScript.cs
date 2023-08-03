using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTriggerScript : MonoBehaviour
{
    // The logic script.
    private LogicScript logic;

    /// <summary>
    /// This is a function that runs code on class when its rendered for the first time.
    /// </summary>
    /// <returns>void</returns>
    void Start()
    {
        // Get the logic script.
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    /// <summary>
    /// This is a function that runs code on every frame after being rendered.
    /// </summary>
    /// <returns>void</returns>
    void Update()
    {
        
    }

    /// <summary>
    /// This is a function that runs when another object enters in contect with the trigger.
    /// </summary>
    /// <returns>void</returns>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that entered the collision is the bird.
        if (collision.gameObject.layer == 3)
        {
            // If so add to the score.
            logic.addToScore();
        }
    }
}
