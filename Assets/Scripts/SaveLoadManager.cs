using System.Collections.Generic;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

/// Using XMl
public class PlayerData
{
	public string playerName;
	public int health;
	public int levelReached;
	public int highScore;
}

public class SaveLoadManager : MonoBehaviour
{
	//Container for playerValues
	PlayerData pData;

	// Use this for initialization
	void Start()
	{

	}
	// Update is called once per frame
	void Update()
	{

	}
	
	public void UpdateScore(ScoreManager sMan)
	{
		if (sMan.score > PlayerPrefs.GetInt("HighScore", 0)) 
		{
			PlayerPrefs.SetInt("HighScore", score);
		}
	}
}