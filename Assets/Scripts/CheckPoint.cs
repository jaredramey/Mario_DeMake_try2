using UnityEngine;
using System.Collections;
using System.IO;

public class CheckPoint : MonoBehaviour
{
    public LevelManager levelManager;
    public SaveLoadManager saveLoadManager;
    public bool isLastCheckpoint;
    private bool levelLoadable;

    public GameObject lastLevel;

    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager> ();
        saveLoadManager = FindObjectOfType<SaveLoadManager>();
        isLastCheckpoint = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            levelManager.currentCheckpoint = gameObject;
            //Debug.Log("Activated Checkpoint " + transform.position);
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
            SaveLoadManager.currentLevel = Application.loadedLevelName;
            PlayerPrefs.SetString("currentLevel", SaveLoadManager.currentLevel);
            GetAccessibility(GameObject.Find("Finish Flag"));
            if(PlayerPrefs.GetString("currentLevel") == "Level_One")
            {
                levelManager.levelOneComplete = true;
            }
        }
    }
    public void GetAccessibility(GameObject other)
    {
        levelLoadable = other.GetComponent<LevelLoader>().loadable;

        if (other.GetComponent<LevelLoader>().loadable == false)
        {
            other.GetComponent<LevelLoader>().loadable = true;
        }

        if(other.name == "LevelFlag1")
        {
            var nextLevel = GameObject.Find("FinishFlag2");

            nextLevel.GetComponent<LevelLoader>().loadable = true;
        }
    }

    public void GetPreviousLevel(GameObject other)
    {
        lastLevel.name = other.name;
    }
}
