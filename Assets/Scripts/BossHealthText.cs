using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossHealthText : MonoBehaviour
{
    //Boss health
    public static int curHealth;

    //Get the level manager
    private LevelManager levelManager;

    //Text to write health to
    Text myText;

    // Use this for initialization
    void Start()
    {
        //Get the Text
        myText = GetComponent<Text>();

        //Get Level Manager
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get life total and display it
        curHealth = FindObjectOfType<BossController>().health;

        //update text on screen
        myText.text = "" + curHealth;
    }
}
