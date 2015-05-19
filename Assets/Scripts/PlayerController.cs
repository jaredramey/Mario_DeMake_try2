using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //Variabls for player
    //Speed for movement
    public float moveSpeed;
    public float jumpHeight;

    //For player ground detection
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private bool doubleJumped;

    private float moveVelocity;

    


    //For animation
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //For physics stuff dealing with player
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        //Check for Double Jumped
        if (grounded)
        {
            doubleJumped = false;
        }

        //Check to see if the jump animation should play or not
        anim.SetBool("Grounded", grounded);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }
        //Double Jump
        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            doubleJumped = true;
        }

        //Move velocity reset to 0 for no sliding
        moveVelocity = 0f;

        //Move Left
        if (Input.GetKey(KeyCode.A))
        {
            //old code
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            //new code
            moveVelocity = -moveSpeed;

        }
        //Move Right
        if (Input.GetKey(KeyCode.D))
        {
            //old code
            //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            //new code
            moveVelocity = moveSpeed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);


        //Mathf.Abs will take a value and return absolute value
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        //flipping the player left or right
        if(GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}

    