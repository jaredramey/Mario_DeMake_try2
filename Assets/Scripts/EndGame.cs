using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour
{

    private GameObject LadyKiller;
    public string LevelToLoad;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LadyKiller = GameObject.Find("ladyKiller");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player" && LadyKiller == null)
        {
            //Should load into end game screen
            Application.LoadLevel(LevelToLoad);
        }
    }
}
