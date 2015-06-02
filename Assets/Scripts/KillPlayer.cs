using UnityEngine;
using System.Collections;


public class KillPlayer : MonoBehaviour
{
    public LevelManager levelManager;

    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Kill the player. New script being used over this one now
        if (other.name == "Player")
        {
            levelManager.RespawnPlayer();
        }
    }
}
