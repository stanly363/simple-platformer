using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Supplycratespawner : MonoBehaviour
{
    public Rigidbody2D SupplyCratePrefab; // The prefab for the supply crate
    public GameObject spawner; // The area where the crates can spawn
    
    
    void Start()
    {
        StartCoroutine(Crate()); // Starts the crate spawning subroutine
    }

    IEnumerator Crate()
    {
        yield return new WaitForSeconds(20); // Starts a 25 second countdown
        Drop(); // Spawns in a crate
    }

    void Drop()
    {
        MeshCollider boundary = spawner.GetComponent<MeshCollider>(); // Gets the area in which the crate can spawn
        float x, y; // Creates a variable for the x and y coordinate
        Vector2 spawnpos; // Creates an empty variable for the spawn position
        x = Random.Range(boundary.bounds.min.x, boundary.bounds.max.x); // Generates a random x spawn position
        y = Random.Range(boundary.bounds.min.y, boundary.bounds.max.y); // Generates a random y spawn postiion
        spawnpos = new Vector2(x,y); // Sets the spawn position equal to the random x and y coordinate
        Rigidbody2D clone = Instantiate(SupplyCratePrefab, spawnpos, Quaternion.identity); // Instantiates the crate object at the  random spawn position
        StartCoroutine(Crate()); // Calls the craate function to start the countdown again
    }
}


