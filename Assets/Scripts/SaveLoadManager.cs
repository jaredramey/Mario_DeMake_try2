using System.Collections.Generic;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour 
{
    LevelLoader LevelLoad;
    public static string currentLevel;
	// Use this for initialization
	void Start()
	{
        LevelLoad = FindObjectOfType<LevelLoader>();
        //setting all values to be saved with PlayerPrefs
        PlayerPrefs.SetInt("LevelOneHighScore", 0);
        PlayerPrefs.SetInt("LevelTwoHighScore", 0);
        PlayerPrefs.SetInt("LevelThreeHighScore", 0);
        PlayerPrefs.SetString("currentLevel", currentLevel);
	}

	// Update is called once per frame
	void Update()
	{

    }
}