using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    //Max health a player can have
    public int maxPlayerHealth;

    //Current Player Life Total
    public static int lifeTotal;

    private LevelManager levelManager;

    //Text to write to score
    Text myText;


    // Use this for initialization
    void Start()
    {
        //Get the text
        myText = GetComponent<Text>();

        //limit health a player can have
        maxPlayerHealth = 99;
        
        //Start the score at 0
        lifeTotal = 3;

        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTotal <= 0)
        {
            //Return the player to the world map
            lifeTotal = 0;

            Application.LoadLevel("LevelSelector");
        }

        myText.text = "" + lifeTotal;
    }

    public static void HurtPlayer(int damageToGive)
    {
        lifeTotal -= damageToGive;
    }

    public void FullHealth()
    {
        lifeTotal = 3;
    }

   
}
