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
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHitting = Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, whatIsPlayer);
        animator.SetBool("itemIsSpawned", itemIsSpawned);
        SpawnItem();
    }

    void SpawnItem()
    {
        if(playerHitting && itemIsSpawned == false)
        {
            Instantiate(itemToSpawn, (gameObject.transform.position + new Vector3(0f, 1f, 0f)), gameObject.transform.rotation);
            itemIsSpawned = true;
        }
    }
}
