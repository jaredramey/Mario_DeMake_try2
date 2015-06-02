using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    private bool playerInZone;
    public string levelToLoad;

    public bool levelAccessible;

    // Use this for initialization
    void Start()
    {
        playerInZone = false;
        levelAccessible = true;
        //make all levels available except Two, three, or boss Level
        //this is so all other doors are automatically available i.e. WM, MainMenu, Quit, etc.
        if (gameObject.name == "Level Two" || gameObject.name == "Level Three" || gameObject.name == "Boss")
        {
            levelAccessible = false;
        }

        //if player has reached level two make level Two available
        if (gameObject.name == "Level Two")
        {

            if (SaveLoadManager.currentLevel >= 1)
            {

                levelAccessible = true;
                Debug.Log("Level Two Accessible");
            }
        }

        if (gameObject.name == "Level Three")
        {

            if (SaveLoadManager.currentLevel >= 2)
            {

                levelAccessible = true;
                Debug.Log("Level Two Accessible");
            }
        }

        if (gameObject.name == "Boss")
        {

            if (SaveLoadManager.currentLevel >= 3)
            {

                levelAccessible = true;
                Debug.Log("Level Two Accessible");
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       //If the player wants to quit then exit the game
        if (Input.GetKeyDown(KeyCode.W) && playerInZone == true && levelAccessible == true)
        {
            if(levelToLoad == "Quit")
            {
                Application.Quit();
                Debug.Log("You just lost the game");
            }
            ChangeLevelAvailability();
            Application.LoadLevel(levelToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //make sure player is in the are
        if(other.name == "Player")
        {
            playerInZone = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        //check if the player has left the zone
        if (other.name == "Player")
        {
            playerInZone = false;
        }

    }

    //Check to see if levels are avaliable
    void ChangeLevelAvailability()
    {
		//--changing levels accessiblitly based on currentLevel--
        if (gameObject.name == "Level Two" && SaveLoadManager.currentLevel >= 1)
        {
            levelAccessible = true;
        }

        if (gameObject.name == "Level Three" && SaveLoadManager.currentLevel >= 2)
        {
            levelAccessible = true;
        }

        if (gameObject.name == "Boss" && SaveLoadManager.currentLevel >= 3)
        {
            levelAccessible = true;
        }
		//-\-changing levels accessiblitly based on currentLevel-\-


    }

}
