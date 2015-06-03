using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour
{
    //Set value for how hurt the player will be
    public int damageToGive;

    //get the level manager
    private LevelManager levelManager;

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
        if (other.name == "Player")
        {
            //hurt player and update the life total
            HealthManager.HurtPlayer(damageToGive);
            //respawn the player
            levelManager.RespawnPlayer();
        }
    }
}
