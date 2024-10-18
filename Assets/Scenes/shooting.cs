using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class shooting : MonoBehaviour
{
    // Variables
    public KeyCode shoot;
    public Rigidbody2D bullet;
    public Rigidbody2D pistol;
    public Rigidbody2D FirePoint;
    private float ammo = 5;
    private bool canReload = true;
    private bool canShoot = true;
    public Rigidbody2D rocket;
    public Rigidbody2D RocketLauncher;
    public Rigidbody2D Sniper;
    public Rigidbody2D MiniGun;
    public Transform rocketFirepoint;
    public Transform MinigunFirepoint;
    public Transform SniperFirepoint;
    public bool CanShootRocket;
    public bool CanShootMinigun;
    public bool CanShootSniper;
    
    void Start()
    {
        CanShootRocket = true;
        CanShootSniper = true;
        CanShootMinigun = true;// Initialises the variable to true
    }
    void Update()
    {
        
        if (pistol.gameObject.activeSelf != true && Input.GetKey(shoot)) // Checks if the player can shoot a rocket
        {
            if (Sniper.gameObject.activeSelf == true && CanShootSniper == true)
            {
               
                Sniperfire();
                CanShootSniper = false;
                Debug.Log("Sniper");

            }
            if (MiniGun.gameObject.activeSelf == true && CanShootMinigun == true)
            {
                
                MiniGunfire();
                CanShootMinigun = false;
                Debug.Log("Minigun");
            }
            if (RocketLauncher.gameObject.activeSelf == true && CanShootRocket == true)
            {
                
                rocketfire();
                CanShootRocket = false;
                Debug.Log("Rocket");
            } // Fires a rocket
        }
        if (Input.GetKey(shoot) && ammo > 0 && canShoot && pistol.gameObject.activeSelf != false) // Checks if the player can shoot a bullet
        {
            Debug.Log("fire");
            fire(); // Fires a bullet
            ammo -= 1; // Reduces the ammo count by one       
        }
        if (ammo == 0 && canReload) // Checks if the player needs to reload
        {
            StartCoroutine(reload()); // Starts a timer to prevent the player from shooting
            canReload = false; // Prevents the player from reloading multiple times
        }
    }
    IEnumerator reload()
    {
        yield return new WaitForSeconds(3); // Starts a countdown for three seconds
        ammo = 5; // Resets the ammo count to its original value of five
        canReload = true; // Allows the player to reload 
    }

    void rocketfire()
    {
        if (transform.localScale.x == -1) // Checks the direction the player is facing
        {
            Rigidbody2D Clone = Instantiate(rocket, rocketFirepoint.position, Quaternion.identity); // Instantiates a rocket
            Clone.transform.localScale = new Vector2(-1, 1); // Rotates the image to face left
            Clone.velocity = new Vector2(-50, Clone.velocity.y); // Moves the rocket left

        }
        else
        {
            Rigidbody2D Clone = Instantiate(rocket, rocketFirepoint.position, Quaternion.identity); // Instantiates a rocket
            Clone.velocity = new Vector2(50, Clone.velocity.y); // Moves the rocket left

        }

         // Prevents the player from shooting a rocket
        StartCoroutine(RocketDelay()); // Starts a timer to prevent the player from repeatedly shootng the rocket
        IEnumerator RocketDelay()
        {
            yield return new WaitForSeconds(1.5f); // Starts a timer for 1.5 seconds
            CanShootRocket = true; // Allows the player to shoot again
        }
    }
    void fire()
    {

        if (transform.localScale.x == -1) // Checks the direction which the player is facing
        {
            Rigidbody2D Clone = Instantiate(bullet, FirePoint.position, Quaternion.identity); // Instantiates a bullet
            Clone.transform.localScale = new Vector2(-1, 1); // Rotates the image to face left
            Clone.velocity = new Vector2(-50, Clone.velocity.y); // Moves the bullet left
        }
        else
        {
            Rigidbody2D Clone = Instantiate(bullet, FirePoint.position, Quaternion.identity); // Instantiates a bullet
            Clone.velocity = new Vector2(50, Clone.velocity.y); // Moves the rocket right
        }
        canShoot = false; // Prevents the player from shooting
        StartCoroutine(Delay()); // Starts a timer to prevent the player from shooting straight away

        IEnumerator Delay()
        {
            yield return new WaitForSeconds(0.25f); // Starts a timer for 0.25 seconds
            canShoot = true; // Allows the player to shoot again
        }
    }
    void Sniperfire()
    {
        if (transform.localScale.x == -1) // Checks the direction which the player is facing
        {
            Rigidbody2D Clone = Instantiate(bullet, SniperFirepoint.position, Quaternion.identity); // Instantiates a bullet
            Clone.transform.localScale = new Vector2(-1, 1); // Rotates the image to face left
            Clone.velocity = new Vector2(-200, Clone.velocity.y); // Moves the bullet left
        }
        else
        {
            Rigidbody2D Clone = Instantiate(bullet, SniperFirepoint.position, Quaternion.identity); // Instantiates a bullet
            Clone.velocity = new Vector2(200, Clone.velocity.y); // Moves the rocket right
        }
         // Prevents the player from shooting
        StartCoroutine(SniperDelay()); // Starts a timer to prevent the player from shooting straight away

        IEnumerator SniperDelay()
        {
            yield return new WaitForSeconds(0.25f); // Starts a timer for 0.25 seconds
            CanShootSniper = true; // Allows the player to shoot again
        }
    }
    void MiniGunfire()
    {
        if (transform.localScale.x == -1) // Checks the direction which the player is facing
        {
            Rigidbody2D Clone = Instantiate(bullet, MinigunFirepoint.position, Quaternion.identity); // Instantiates a bullet
            Clone.transform.localScale = new Vector2(-1, 1); // Rotates the image to face left
            Clone.velocity = new Vector2(-50, Clone.velocity.y); // Moves the bullet left
        }
        else
        {
            Rigidbody2D Clone = Instantiate(bullet, MinigunFirepoint.position, Quaternion.identity); // Instantiates a bullet
            Clone.velocity = new Vector2(50, Clone.velocity.y); // Moves the rocket right
        }
        // Prevents the player from shooting
        StartCoroutine(MinigunDelay()); // Starts a timer to prevent the player from shooting straight away

        IEnumerator MinigunDelay()
        {
            yield return new WaitForSeconds(0.1f); // Starts a timer for 0.25 seconds
            CanShootMinigun = true; // Allows the player to shoot again
        }
    }
}   
       


