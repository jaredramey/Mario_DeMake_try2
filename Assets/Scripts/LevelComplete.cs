using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            //--checking if current level needs to be increased--
            //if loaded level is level one
            if (SceneManager.GetActiveScene().name == "Level_One")
            {
                //if player makes it back without dying (lifeTotal > 0)
                //if he hasnt already beaten this level increase the finished levels
                if (HealthManager.lifeTotal > 0 && PlayerPrefs.GetInt("currentLevel_Slot_" + SaveLoadManager.playerSlot.ToString()) < 2)
                {
                    SaveLoadManager.currentLevel++;
                    PlayerPrefs.SetInt("currentLevel_Slot_" + SaveLoadManager.playerSlot.ToString(), SaveLoadManager.currentLevel);
                    Debug.Log("saved level: " + SaveLoadManager.currentLevel);
                    //check the highscore, keep highest number as new high score
                    if (ScoreManager.score > PlayerPrefs.GetInt("LevelOneHighScore"))
                        PlayerPrefs.SetInt("LevelOneHighScore", ScoreManager.score);
                }
            }
            //if loaded level is level two
            if (SceneManager.GetActiveScene().name == "Level_Two")
            {
                //if player makes it back without dying (lifeTotal > 0)
                //if he hasnt already beaten this level increase the finished levels
                if (HealthManager.lifeTotal > 0 && PlayerPrefs.GetInt("currentLevel_Slot_" + SaveLoadManager.playerSlot.ToString()) < 3)
                {
                    SaveLoadManager.currentLevel++;
                    PlayerPrefs.SetInt("currentLevel_Slot_" + SaveLoadManager.playerSlot.ToString(), SaveLoadManager.currentLevel);
                    Debug.Log("saved level: " + SaveLoadManager.currentLevel);
                    //check the highscore, keep highest number as new high score
                    if (ScoreManager.score > PlayerPrefs.GetInt("LevelTwoHighScore"))
                        PlayerPrefs.SetInt("LevelTwoHighScore", ScoreManager.score);
                }
            }
            //if loaded level is level three
            if (SceneManager.GetActiveScene().name == "Level_Three")
            {
                //if player makes it back without dying (lifeTotal > 0)
                //if he hasnt already beaten this level increase the finished levels
                if (HealthManager.lifeTotal > 0 && PlayerPrefs.GetInt("currentLevel_Slot_" + SaveLoadManager.playerSlot.ToString()) < 4)
                {
                    SaveLoadManager.currentLevel++;
                    PlayerPrefs.SetInt("currentLevel_Slot_" + SaveLoadManager.playerSlot.ToString(), SaveLoadManager.currentLevel);
                    Debug.Log("saved level: " + SaveLoadManager.currentLevel);
                    //check the highscore, keep highest number as new high score
                    if (ScoreManager.score > PlayerPrefs.GetInt("LevelThreeHighScore"))
                        PlayerPrefs.SetInt("LevelThreeHighScore", ScoreManager.score);
                }
            }
            //-\-checking if current level needs to be increased-\-
        }
    }
}
