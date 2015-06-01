using UnityEngine;
using System.Collections;

public class for_Terry : MonoBehaviour
{
    [SerializeField]
    private bool playerInTheZone = false;
    // Use this for initialization
    void Start()
    {
        playerInTheZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        //terry wants a suicide button...
        //so here it is
        //eventually

        //this is a reset button for the save slots
        if (Input.GetKeyDown(KeyCode.W) && playerInTheZone == true)
        {
            PlayerPrefs.SetInt("currentLevel_Slot_1", 0);
            PlayerPrefs.SetInt("currentLevel_Slot_2", 0);
            PlayerPrefs.SetInt("currentLevel_Slot_3", 0);
            Debug.Log("All save slots are set to 0");

#if UNITY_EDITOR
			//UnityEditor.EditorApplication.isPaused = true;
#endif
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInTheZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInTheZone = false;
        }
    }
}
