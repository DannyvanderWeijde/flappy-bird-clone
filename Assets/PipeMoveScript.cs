using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    // The move speed of the pipes.
    public float moveSpeed = 5;
    // The dead zone at which the pipes should be destroyed.
    public float deadZone = -2;
    // The pipeSpawner.
    private PipeSpawnerScript pipeSpawner; 

    /// <summary>
    /// This is a function that runs code on class when its rendered for the first time.
    /// </summary>
    /// <returns>void</returns>
    void Start()
    {
        // Get the pipe spawner.
        pipeSpawner = GameObject.FindGameObjectWithTag("pipeSpawner").GetComponent<PipeSpawnerScript>();
    }

    /// <summary>
    /// This is a function that runs code on every frame after being rendered.
    /// </summary>
    /// <returns>void</returns>
    void Update()
    {
        // Make the pipe move to the left based on the moveSpeed and the real time (Time.deltaTime).
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        // Check if the position of the pipe is bigger than the dead zone.
        if (transform.position.x < (pipeSpawner.maxXPosition + deadZone))
        {
            // Print the text 'deleted'.
            Debug.Log("deleted");
            // Destroy the pipe.
            Destroy(gameObject);
        }
    }
}
