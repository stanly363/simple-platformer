using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class bullet: MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D projectile) // Checks for a collision through Collider2D
    {
        if (projectile.gameObject.name != "bullet" && projectile.gameObject.name != "Rocket")
        {
            Destroy(this.gameObject); // Destroys the game object this is attached to in this case the bullet

        }


    }
}




