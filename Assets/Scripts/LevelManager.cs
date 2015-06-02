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

    private float gravityStore;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
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
                    //gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
                    //player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //Delay between death and respawn
        yield return new WaitForSeconds(respawnDelay);
        //Tell the log that the player has died
        Debug.Log("Player Respawned");
        //Move the player
        player.transform.position = currentCheckpoint.transform.position;
        //Turn the player back on
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
                                                        //player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        //Play respawn particle
        Instantiate(RespawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
