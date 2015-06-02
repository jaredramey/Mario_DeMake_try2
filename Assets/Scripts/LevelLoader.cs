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
        if (gameObject.name == "Level Two")
        {
            levelAccessible = false;
        }

        //if player has reached level two make level Two available
        if (gameObject.name == "Level Two")
        {
            //Debug.Log("Level two script started. Levels complete = " + PlayerPrefs.GetInt("currentLevel_Slot_" + SaveLoadManager.playerSlot.ToString()));
            //SaveLoadManager.currentLevel = PlayerPrefs.GetInt("currentLevel_Slot_" + SaveLoadManager.playerSlot.ToString());
			//Debug.Log("currentLevel: " + SaveLoadManager.currentLevel);

            if (SaveLoadManager.currentLevel >= 1)
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
        //if loaded level is level one
        if(Application.loadedLevelName == "Level_1")
        {
            //if player makes it back without dying (lifeTotal > 0)
            //if he hasnt already beaten this level increase the finished levels
            if (HealthManager.lifeTotal > 0 && PlayerPrefs.GetInt("currentLevel_Slot_" + SaveLoadManager.playerSlot.ToString()) < 2)
            {
                SaveLoadManager.currentLevel++;
                PlayerPrefs.SetInt("currentLevel_Slot_" + SaveLoadManager.playerSlot.ToString(), SaveLoadManager.currentLevel);
                Debug.Log("saved level: " + SaveLoadManager.currentLevel);
            }
        }
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
    }

}
