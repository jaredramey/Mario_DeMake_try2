using UnityEngine;
using System.Collections;

public class CageControl : MonoBehaviour
{

    public GameObject Enemy;
    public bool isEnemyAlive;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckForEnemy();

        if(isEnemyAlive == false)
        {
            print("Enemy died");

            int childs = gameObject.transform.childCount;
            for(int i = childs - 1; i >= 0; i--)
            {
                Destroy(gameObject.transform.GetChild(i).gameObject);
            }
        }
    }

    void CheckForEnemy()
    {
        if(GameObject.Find(Enemy.name))
        {
            isEnemyAlive = true;
        }
        else
        {
            isEnemyAlive = false;
        }
    }
}
