using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Restart() // Is called when the restart button is pressed
    {
        Debug.Log("Restart"); // Outputs the restart output in the console on click
        SceneManager.LoadScene("game"); // Loads the game scene to restart the game
    }

    public void MainMenu() // Is called when the main menu button is pressed
    {
        SceneManager.LoadScene("MainMenu"); // Loads the main menau scene on click
    }
}
