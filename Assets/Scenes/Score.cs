using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //variables
    public Text ScorePlayer1;
    public Text ScorePlayer2;
    public Rigidbody2D player1;
    public Rigidbody2D player2;
    public bool CanChange;
    public int score1;
    public int score2;
    
    void Start()
    {
        //Initialises variables to their starting values
        CanChange = true; 
        score1 = 0;
        score2 = 0; 
    }
    void Update()
    {
        
        if (player1.gameObject.activeSelf == false || player2.gameObject.activeSelf == false) //Checks if a player has won the game
        {
            
            if (CanChange == true && player1.gameObject.activeSelf == false) //Checks if player 1 has lost the game
            {
                score2 += 1; //Increments player twos score by one
                ScorePlayer2.text = (score2.ToString()); //Updates the score on screen for player 2
                CanChange = false; //Prevents the score being changed multiple times
            }
            if (CanChange == true && player2.gameObject.activeSelf == false) //Checks if player 2 has lost the game
            {
                score1 += 1; //Increments player ones score by one
                ScorePlayer1.text = (score1.ToString()); //Updates the score on screen for player one
                CanChange = false; //Prevents the score being changed multiple times
            }
        }
    }
}
