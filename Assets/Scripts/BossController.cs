using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{

    public float moveSpeed;
    public bool moveRight;
    public GameObject DeathParticle;
    public int health;
    public float pushVelocity;
    private GameObject player;

    public float playerCheckRadius;
    public bool playerOnTop;
    public Transform playerCheck;
    public LayerMask whatIsPlayer;


    public Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Player Object
        player = GameObject.Find("Player");

        //checking for player
        playerOnTop = Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, whatIsPlayer);

        Movement();
        KillEnemy();
    }

    void Movement()
    {
        //get player pos difference from boss
        //var BossToPlayerPos = new Vector2((player.GetComponent<Rigidbody2D>().velocity.x - GetComponent<Rigidbody2D>().velocity.x), 0.0f);  //<-- Call that I might need later
        if(player == null)
        {
            if(gameObject.transform.position.x <= 5.9)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }

            else if (gameObject.transform.position.x >= 5.9)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
        }

        //if the player is to the right of the boss
        if(gameObject.transform.position.x <= player.transform.position.x)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveRight = true;
        }

        else if (gameObject.transform.position.x >= player.transform.position.x)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveRight = false;
        }

        if (moveRight)
        {
            transform.localScale = new Vector3(-4.6f, 4f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(4.6f, 4f, 1f);
        }

        //Regular Enemy Movement
        //if (!atEdge)
        //{
        //    moveRight = !moveRight;
        //}
        //if (moveRight)
        //{
        //    transform.localScale = new Vector3(-1f, 1f, 1f);
        //    GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        //}
        //else
        //{
        //    transform.localScale = new Vector3(1f, 1f, 1f);
        //    GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        //}
    }

    void KillEnemy()
    {
        if (playerOnTop && health <= 0)
        {
            Instantiate(DeathParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            return;
        }

        else if(playerOnTop)
        {
            health = health - 1;
            player.GetComponent<Rigidbody2D>().velocity += new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, pushVelocity);
        }

        //Set the bool in the animator so the attack animation can trigger
        anim.SetBool("PlayerOnTop", playerOnTop);
    }
}
