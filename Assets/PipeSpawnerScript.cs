using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    // The pipe.
    public GameObject pipe;
    // The spawn rate.
    public float spawnRate = 2;
    // The timer.
    private float timer = 0;
    // The height offset.
    public float heightOffset = 5;

    /// <summary>
    /// This is a function that runs code on class  when its rendered for the first time.
    /// </summary>
    /// <returns>void</returns>
    void Start()
    {
        // Spawn a pipe on game load.
        spawnPipe();
    }

    /// <summary>
    /// This is a function that runs code on every frame after being rendered.
    /// </summary>
    /// <returns>void</returns>
    void Update()
    {
        // Check if its time to spawn a new pipe.
        if (timer < spawnRate)
        {
            // If not increase the timer.
            timer += Time.deltaTime;
        } else
        {
            // If so spawn a new one.
            spawnPipe();
            // Set the timer back to 0.
            timer = 0;
        }
    }

    /// <summary>
    /// This is a function that spawns a pipe.
    /// </summary>
    /// <returns>void</returns>
    void spawnPipe()
    {
        // The lowest point of the canvas.
        float lowestPoint = transform.position.y - heightOffset;
        // The highest point of the canvas.
        float highestPoint = transform.position.y + heightOffset;
        
        // Create a new pipe with a random y value that is between the lowest and highest points.
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
