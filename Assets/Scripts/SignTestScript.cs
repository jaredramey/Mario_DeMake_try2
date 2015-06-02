using UnityEngine;
using System.Collections;

public class SignTestScript : MonoBehaviour
{
    public TextMesh signText;
    public string Text;

    // Use this for initialization
    void Start()
    {
        if (gameObject.name == "HighScoreSign")
            signText.text = "High Scores \n"
                 + "Level One:" + PlayerPrefs.GetInt("LevelOneHighScore").ToString() + "\n"
                 + "Level Two:" + PlayerPrefs.GetInt("LevelTwoHighScore").ToString() + "\n"
                 + "Level Three:" + PlayerPrefs.GetInt("LevelThreeHighScore").ToString();
        else if (Text == "")
            Text = signText.text;
        else
            signText.text = Text;
    }

    // Update is called once per frame
    void Update()
    {
        signText.GetComponent<MeshRenderer>().sortingLayerName = "Interactables Layer";
    }
}
