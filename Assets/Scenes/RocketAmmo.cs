using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketAmmo : MonoBehaviour
{
    // Variables
    public float ExplosionRange;
    public Rigidbody2D RocketPos;
    public LayerMask Player;
    public bool IsNearPlayer;
    public Slider slider;
    public Slider slider2;
    public Animator playerAnimator;



    private void OnTriggerEnter2D(Collider2D projectile) // Checks for a collision
    {
        // Checks if player is within range of the explosion
        RocketPos.velocity = new Vector2(0, 0);
        playerAnimator.SetBool("Explosion", true);
        Debug.Log("lol");
        StartCoroutine(DestroyRocket());
        if (projectile.gameObject.name != "Rocket" && projectile.gameObject.name != "bullet")
        {
            if (IsNearPlayer == true)
            {
                if (projectile.gameObject.name == "Player2")
                {
                    slider2.value -= 5;
                }
                if (projectile.gameObject.name == "Player1")
                {
                    slider.value -= 5;
                }// Calls a function within the healthbar code
            }


             
        }
        IEnumerator DestroyRocket()
        {
            
            yield return new WaitForSeconds(0.3f);
            Destroy(this.gameObject);



        }
        

    }

    void Update()
    {
        IsNearPlayer = Physics2D.OverlapCircle(RocketPos.position, ExplosionRange, Player); // Checks if a player is in range of the explosion
        

    }



}
