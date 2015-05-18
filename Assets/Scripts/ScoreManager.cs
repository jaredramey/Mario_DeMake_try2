using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //Player score throuought the game
    public static int score;

    //Text to write to score
    Text myText;

    void Start()
    {
        //Get the text
        myText = GetComponent<Text>();

        //Start the score at 0
        score = 0;
    }

    void Update()
    {
        //Make sure player can't go below 0
        if(score < 0)
        {
            score = 0;
        }

        //Display score
        myText.text = "" + score;
    }

    public static void AddCoins(int pointsToAdd)
    {
        //If the player gets points then add points
        score = score += pointsToAdd;
    }

    public static void Reset()
    {
        //If the score needs to be reset
        score = 0;
    }
}
