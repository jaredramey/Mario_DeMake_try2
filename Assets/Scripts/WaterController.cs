using UnityEngine;
using System.Collections;

public class WaterController : MonoBehaviour
{

    private PlayerController player;

    public float waterGravity;
    public float normalGravity;

    public Transform playerCheck;
    public float playerCheckRadius;
    public LayerMask whatIsPlayer;
    private bool playerHere;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<PlayerController>();
        playerHere = Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, whatIsPlayer);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = waterGravity;
            Debug.Log("Player Entered");
        }
    }

    void FixGravity()
    {
        if (playerHere)
        {
            player.GetComponent<Rigidbody2D>().gravityScale = normalGravity;
            Debug.Log("Player Exited");
        }
    }
}
