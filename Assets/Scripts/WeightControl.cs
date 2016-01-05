using UnityEngine;
using System.Collections;

public class WeightControl : MonoBehaviour
{
    /*
     * Simple script that is used to check if this weight has hit
     * lady killer and if so destroy the game object. 
     * Will probably model a script after this later on for blocks
     * that will kill enemies in regular world levels.
     */
    private GameObject ladyKiller;

    public float bossCheckRadius;
    public bool hitBoss;
    public Transform bossCheck;
    public LayerMask whatIsBoss;

    public float destuctionDelay;


    // Use this for initialization
    void Start()
    {
        //Fill in later if needed
    }

    // Update is called once per frame
    void Update()
    {
        //Get boss object
        ladyKiller = GameObject.Find("ladyKiller");

        //check to see if the boss is under the wieght
        hitBoss = Physics2D.OverlapCircle(bossCheck.position, bossCheckRadius, whatIsBoss);

        //Check to see if object destruction is needed
        ObjectStatusCheck();
    }

    void ObjectStatusCheck()
    {
        if(hitBoss)
        {
            //If the block has hit the boss then destroy the block
            Destroy(gameObject, destuctionDelay);
        }
    }
}
