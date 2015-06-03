using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour
{
    //Getting animator to use the variable from there
    Animator animator;

    //Get object to be spawned
    public GameObject itemToSpawn;

    //Be able to check for player
    public float playerCheckRadius;
    private bool playerHitting;
    public Transform playerCheck;
    public LayerMask whatIsPlayer;

    //See if an object was already spawned
    public bool itemIsSpawned = false;


    // Use this for initialization
    void Start()
    {
        //get the animator
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if the player is hitting
        playerHitting = Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, whatIsPlayer);
        //update the animator
        animator.SetBool("itemIsSpawned", itemIsSpawned);
        //spawn the item
        SpawnItem();
    }

    void SpawnItem()
    {
        if(playerHitting && itemIsSpawned == false)
        {
            //create the item above the block
            Instantiate(itemToSpawn, (gameObject.transform.position + new Vector3(0f, 1f, 0f)), gameObject.transform.rotation);
            //make it so no other items can spawn out of the block
            itemIsSpawned = true;
        }
    }
}
