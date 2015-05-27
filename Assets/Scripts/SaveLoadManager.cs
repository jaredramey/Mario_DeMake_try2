using System.Collections.Generic;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static string currentLevel;
    public static int playerSlot;
    // Use this for initialization
    void Start()
    {
        //setting all values to be saved with PlayerPrefs
        PlayerPrefs.SetInt("LevelOneHighScore", 0);
        PlayerPrefs.SetInt("LevelTwoHighScore", 0);
        PlayerPrefs.SetInt("LevelThreeHighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void NewSlotOne(string name)
    {
        PlayerPrefs.SetInt("currentLevel_Slot_1", 0);
        PlayerPrefs.SetString("Slot_1_Name", name);
        playerSlot = 1;
    }

    public void NewSlotTwo(string name)
    {
        PlayerPrefs.SetInt("currentLevel_Slot_2", 0);
        PlayerPrefs.SetString("Slot_2_Name", name);
        playerSlot = 2;
    }

    public void NewSlotThree(string name)
    {
        PlayerPrefs.SetInt("currentLevel_Slot_3", 0);
        PlayerPrefs.SetString("Slot_3_Name", name);
        playerSlot = 3;
    }
}
