using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour
{
    //Set value for how hurt the player will be
    public int damageToGive;


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
            HealthManager.HurtPlayer(damageToGive);
            levelManager.RespawnPlayer();
        }
    }
}
