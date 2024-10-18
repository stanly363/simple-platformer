using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS: MonoBehaviour
{
    public InputField iField; // Defines the Input field
    void Start() { 
        Application.targetFrameRate = 60;} // Automatically sets the frames per second to 60


    void Update()
    {
        var input = iField.text; // Collects all text in the input field
        if (int.TryParse(input, out int value)) { // Checks if the inputted value can be converted to an integer
            if (input != null && int.Parse(input) > 0 && int.Parse(input) <= 240) // Checks if the inputted value is valid
                {
                Application.targetFrameRate = int.Parse(input); // Sets the frames per second equal to the inputted value
            }
            else
            {
                Application.targetFrameRate = 60; // If the input value fails validation the frames per second is set back to 60
            }
            }
            
    }
}


