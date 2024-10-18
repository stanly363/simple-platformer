using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    // Variables
    public Slider slider;
    public Rigidbody2D bullet;
    public Image fill;
    public Gradient gradient;
    public Text Wintext;
    public GameObject GameoverScreen;
    public bool Rocket = false;
    
    




    void Update()
    {
        if (slider.value == 0) // If the health is zero
        {
            
            this.gameObject.SetActive(false); // Removes the losing player
            GameoverScreen.SetActive(true); // Displays the Game over screen
            if (this.gameObject.name == "Player1") // Checks the name of the losing player
            {
                Wintext.text = "Player 2 Wins"; // Displays the winning player
            } else
            {
                Wintext.text = "Player 1 Wins"; // Displays the winning player
            }
            
        }

    }
    
    
    public void SetMaxHealth(int health)
    {
        // Defines the maximum value of the slider and resets it to full health
         slider.maxValue = health; 
         slider.value = health;

            fill.color = gradient.Evaluate(1f); // Fills the health bar with a red colour
    }
   

    public void SetHealth(int health)
    {
        // Sets the slider equal to the health value
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void OnTriggerEnter2D(Collider2D bullet)
    {
        
            slider.value -= 1;
        
        
        
    }    
}




