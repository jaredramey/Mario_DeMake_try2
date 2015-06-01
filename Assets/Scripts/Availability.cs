using UnityEngine;
using System.Collections;

public class Availability : MonoBehaviour {

    public int availableLevels;



	// Use this for initialization
	void Start ()
    {
        //saveLoadManager = FindObjectOfType<SaveLoadManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        availableLevels = PlayerPrefs.GetInt("currentLevel");
        UpdateLevelAccess();
	}

    public void UpdateLevelAccess()
    {
        for(int i = 0; i < availableLevels; i++)
        {
            //list of flags
            //set flags loadable to true for
            //total number of avaiable levels

        }
    }

  
}
