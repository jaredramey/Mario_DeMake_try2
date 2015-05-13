using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    private PlayerController player;

    //Particle Animations
    public GameObject DeathParticle;
    public GameObject RespawnParticle;

    public float respawnDelay;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCo());
    }

    //Co Routine for player pause
    public IEnumerator RespawnPlayerCo()
    {
        //Play death particle
        Instantiate(DeathParticle, player.transform.position, player.transform.rotation);
        //Disable Player
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        //Delay between death and respawn
        yield return new WaitForSeconds(respawnDelay);
        //Tell the log that the player has died
        Debug.Log("Player Respawned");
        //Move the player
        player.transform.position = currentCheckpoint.transform.position;
        //Turn the player back on
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        //Play respawn particle
        Instantiate(RespawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
