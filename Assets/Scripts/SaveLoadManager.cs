using System.Collections.Generic;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour 
{
    public bool[] isAccessable = new bool[3]{true, false, false};
    public int currentLevel;
    LevelLoader LevelLoad;
	// Use this for initialization
	void Start()
	{
        LevelLoad = FindObjectOfType<LevelLoader>();

	}

	// Update is called once per frame
	void Update()
	{
        if (Application.loadedLevelName != "LevelSelector")
        {
            for (int i = 0; i < isAccessable.Length; i++)
            {
                if(isAccessable[i] != false)
                {
                    i++;
                    isAccessable[i] = true;
                    return;
                }
            }
        }
    }
}