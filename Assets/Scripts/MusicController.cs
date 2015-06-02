using UnityEngine;
using System.Collections;


/*
 *Can be used for more stuff later on but for now just using it to keep the
 *music loaded through each scene
 */
public class MusicController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (FindObjectsOfType<MusicController>().Length > 1)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
