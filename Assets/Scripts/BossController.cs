using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    //Stuff for the boss
    public float moveSpeed;
    public bool moveRight;
    public GameObject DeathParticle;
    public int health;
    public Animator anim;

    //Stuff for the player
    public float pushVelocity;
    private GameObject player;
    public float playerCheckRadius;
    public bool playerOnTop;
    public Transform playerCheck;
    public LayerMask whatIsPlayer;

    //Stuff for the weight
    public GameObject weight;
    public bool hitByWeight;
    public LayerMask whatIsWeight;
    public float weightCheckRadius;
    /*== Will be using player check for transform check*/

    // Use this for initialization
    void Start()
    {
        //get the animator for the boss
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Player Object
        player = GameObject.Find("Player");
        //checking for player & for weight
        playerOnTop = Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, whatIsPlayer);
        hitByWeight = Physics2D.OverlapCircle(playerCheck.position, weightCheckRadius, whatIsWeight);
        //Move
        Movement();
        //check and see if hitting player
        KillEnemy();
        //check to see if hit by weight
        WeightCheck();
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
        //check if the player is on the left of the boss
        else if (gameObject.transform.position.x >= player.transform.position.x)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveRight = false;
        }

        //Move left or right
        //Flips the boss' sprite to face the right way
        if (moveRight)
        {
            transform.localScale = new Vector3(-4.6f, 4f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(4.6f, 4f, 1f);
        }
    }

    void KillEnemy()
    {
        //else push the player up
        if(playerOnTop)
        {
            //Setting the max velocity that the player can go
            Vector2 maxVel = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, pushVelocity);

            //check to make sure that players velocity doesn't go too high when pushing player up
            if(player.GetComponent<Rigidbody2D>().velocity.y < maxVel.y)
            {
                player.GetComponent<Rigidbody2D>().velocity += new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, pushVelocity);
            }
            else 
            {
                player.GetComponent<Rigidbody2D>().velocity += new Vector2(0, 0);
            }
            
        }

        //Set the bool in the animator so the attack animation can trigger
        anim.SetBool("PlayerOnTop", playerOnTop);
    }

    void WeightCheck()
    {
        //check if the boss is dead
        if (hitByWeight && health <= 0)
        {
            Instantiate(DeathParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
            return;
        }

        else if(hitByWeight)
        {
            health--;
        }
    }
}
