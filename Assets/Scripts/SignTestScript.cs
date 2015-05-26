using UnityEngine;
using System.Collections;

public class SignTestScript : MonoBehaviour
{
    public TextMesh signText;
    public string Text;

    // Use this for initialization
    void Start()
    {
        //set the sign text
        signText.text = Text;
    }

    // Update is called once per frame
    void Update()
    {
        signText.GetComponent<MeshRenderer>().sortingLayerName = "Interactables Layer";
    }
}
