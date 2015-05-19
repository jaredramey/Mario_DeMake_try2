using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight;

    public GameObject DeathParticle;

    //For wall check with Enemy
    public Transform WallCheck;
    public float WallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool atEdge;
    public Transform edgeCheck;
    public LayerMask whatIsGround;

    public float playerCheckRadius;
    private bool playerOnTop;
    public Transform playerCheck;
    public LayerMask whatIsPlayer;

    public int pointsOnDeath;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //checking if hit a wall
        hittingWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, whatIsWall);

        //checking for ledge
        atEdge = Physics2D.OverlapCircle(edgeCheck.position, WallCheckRadius, whatIsGround);

        //checking for player
        playerOnTop = Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, whatIsPlayer);

        KillEnemy();
        EnemyMovement();
    }

    void EnemyMovement()
    {
        if (hittingWall || !atEdge)
        {
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void KillEnemy()
    {
        if (playerOnTop)
        {
            Instantiate(DeathParticle, gameObject.transform.position, gameObject.transform.rotation);
            ScoreManager.AddCoins(pointsOnDeath);
            Destroy(gameObject);
            return;
        }
    }
}
