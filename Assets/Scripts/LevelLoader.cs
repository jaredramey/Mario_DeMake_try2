using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    private bool playerInZone;
    public string levelToLoad;
    public bool loadable;
    public bool keepLoaded;

    string one = "1";
    string two = "2";

    // Use this for initialization
    void Start()
    {
        playerInZone = false;
        loadable = false;
        keepLoaded = false;

        if (gameObject.name == ("LevelFlag" + one))
        {
            loadable = true;
            keepLoaded = true;
        }
        else if (gameObject.name == ("LevelFlag" + two))
        {
            keepLoaded = true;
        }

        if(keepLoaded == true)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && playerInZone == true && loadable == true)
        {
            Application.LoadLevel(levelToLoad);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            playerInZone = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = false;
        }
    }
}
