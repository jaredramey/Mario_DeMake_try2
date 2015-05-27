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

        if (gameObject.name == "Level Two")
        {
            levelAccessible = false;
        }

        if (gameObject.name == "Level Two")
        {
            Debug.Log("Level two script started. Levels complete = " + PlayerPrefs.GetInt("finishedLevels"));
            if (PlayerPrefs.GetInt("currentLevel_Slot_" + SaveLoadManager.playerSlot) >= 1)
            {
                levelAccessible = true;
                Debug.Log("Level Two Accessible");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        if(other.name == "Player")
        {
            playerInZone = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = false;
        }

    }
    void ChangeLevelAvailability()
    {
            //if loaded level is level one
            if(Application.loadedLevelName.ToString() == "Level_1")
            {
                //if player makes it back without dying (lifeTotal > 0)
                //if he hasnt already beaten this level increase the finished levels
                if (HealthManager.lifeTotal > 0 && PlayerPrefs.GetInt("currentLevel_Slot_" + SaveLoadManager.playerSlot) < 2)
                {
                    PlayerPrefs.SetInt("currentLevel_Slot_" + SaveLoadManager.playerSlot, 1);
                    Debug.Log("" + PlayerPrefs.GetInt("currentLevel_Slot_" + SaveLoadManager.playerSlot));
                }
            }
    }

}
