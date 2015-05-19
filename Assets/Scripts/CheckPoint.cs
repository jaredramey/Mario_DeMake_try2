﻿using UnityEngine;
using System.Collections;
using System.IO;

public class CheckPoint : MonoBehaviour
{
    public LevelManager levelManager;
	public SaveLoadManager SaveTest;

    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager> ();
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
}
