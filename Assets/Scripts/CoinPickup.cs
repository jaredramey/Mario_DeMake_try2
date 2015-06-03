using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour
{
    public int pointsToAdd;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>() == null)
        {
            return;
        }

        //Add coin points to player score
        ScoreManager.AddCoins(pointsToAdd);

        //destroy the item so it can't be picked up again
        Destroy(gameObject);
    }
}
