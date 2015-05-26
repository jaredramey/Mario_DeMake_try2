using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    private bool playerInZone;
    public string levelToLoad;
    public bool loadable;
    public bool isLastCheckpoint;
    public bool keepLoaded;
    private bool levelLoadable;
    SaveLoadManager saveLoadManager;

    public bool levelOneComplete = false;
    public bool levelTwoComplete = false;

    string one = "1";
    string two = "2";

    // Use this for initialization
    void Start()
    {
        playerInZone = false;
        loadable = false;
        keepLoaded = false;
        isLastCheckpoint = false;
        saveLoadManager = FindObjectOfType<SaveLoadManager>();
        

        if (gameObject.name == ("LevelFlag" + one))
        {
            loadable = true;
            keepLoaded = true;
            if(levelOneComplete == true)
            {
                GetAccessibility(GameObject.Find("FinishFlag2"));
            }
        }
        else if (gameObject.name == ("LevelFlag" + two))
        {
            keepLoaded = true;
        }

        if(keepLoaded == true)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        EndOfLevel();
        if(Input.GetKeyDown(KeyCode.W) && playerInZone == true && loadable == true)
        {
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

    public void GetAccessibility(GameObject other)
    {
        levelLoadable = other.GetComponent<LevelLoader>().loadable;

        if (levelLoadable == false)
        {
            levelLoadable = true;
        }

        if (other.name == "LevelFlag1")
        {
            var nextLevel = GameObject.Find("FinishFlag2");

            nextLevel.GetComponent<LevelLoader>().loadable = true;
        }
    }

    //used to update highscore of this level and unlock the next level
    //only used if the last checkpoint is reached
    public void EndOfLevel()
    {
        if(isLastCheckpoint == true)
        {

        //unlock next level
        //this only increases counter
        //bad bug, must make it so only increase current level 
        //if level hasent been beaten before
        //run a check on currentlevels value if under a certain amount increase by one
        //SaveLoadManager.currentLevel = Application.loadedLevelName;
        //PlayerPrefs.SetString("currentLevel", SaveLoadManager.currentLevel);

            if(PlayerPrefs.GetString("currentLevel") == "Level_One")
            {
                levelOneComplete = true;
            }
        }
    }
}
