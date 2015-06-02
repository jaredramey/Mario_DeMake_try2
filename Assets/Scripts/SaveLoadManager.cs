using System.Collections.Generic;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static int currentLevel = 0;
    public static int playerSlot;
    private bool playerInZone = false;

    // Use this for initialization
    void Start()
    {
        //setting all values to be saved with PlayerPrefs
        //PlayerPrefs.SetInt("LevelOneHighScore", 0);
        //PlayerPrefs.SetInt("LevelTwoHighScore", 0);
        //PlayerPrefs.SetInt("LevelThreeHighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && playerInZone == true)
        {
            if (this.name == "Slot_1_mid")
            {
				Debug.Log("slot 1");
                int slotOne = 1;
                //if not saved to slot 1, load new game on slot 1
                if (PlayerPrefs.GetInt("currentLevel_Slot_1") == 0)
                {
                    
                    NewSlot(slotOne);
                }
                //otherwise load slot 1
                else
                {
                    LoadSLot(slotOne);
                }
            }
			if (this.name == "Slot_2_mid")
            {
				Debug.Log("slot 2");
                int slotTwo = 2;
                //if not saved to slot 2, load new game on slot
                if (PlayerPrefs.GetInt("currentLevel_Slot_2") == 0)
                {
                    
                    NewSlot(slotTwo);
                }
                //otherwise load slot 2
                else
                {
                    LoadSLot(slotTwo);
                }
            }
			if (this.name == "Slot_3_mid")
			{
				Debug.Log("slot 3");
				int slotThree = 3;
				//if not saved to slot 3, load new game on slot
				if (PlayerPrefs.GetInt("currentLevel_Slot_3") == 0)
				{
					
					NewSlot(slotThree);
				}
				//otherwise load slot 3
				else
				{
					LoadSLot(slotThree);
				}
			}
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
    //save slot without name, for now
    public void NewSlot(int i)
    {
        Debug.Log("Hit :)");
        if (i == 1)
            PlayerPrefs.SetInt("currentLevel_Slot_1", 0);
        else if (i == 2)
            PlayerPrefs.SetInt("currentLevel_Slot_1", 0);
        else if (i == 3)
            PlayerPrefs.SetInt("currentLevel_Slot_3", 0);
        else
            Debug.Log("Not a Accessable save slot, please select a slot 1-3.");

        //set player slot for later access
        playerSlot = i;
    }

    public void LoadSLot(int i)
    {
        //set current level based on the save slot selected
        if (i == 1)
           currentLevel = PlayerPrefs.GetInt("currentLevel_Slot_1");
        else if (i == 2)
            currentLevel = PlayerPrefs.GetInt("currentLevel_Slot_2");
        else if (i == 3)
            currentLevel = PlayerPrefs.GetInt("currentLevel_Slot_3");
        else
            Debug.Log("Not a Accessable save slot, please select a slot 1-3.");

        //set player slot for later access
        playerSlot = i;
    }
}
