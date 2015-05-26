﻿using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    private bool playerInZone;

    public string levelToLoad;

    public bool levelAccessible;

    // Use this for initialization
    void Start()
    {
        playerInZone = false;
        levelAccessible = false;

        if (gameObject.name == "Finish Flag" || gameObject.name == "Level One")
        {
            levelAccessible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && playerInZone == true && levelAccessible == true)
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
}
