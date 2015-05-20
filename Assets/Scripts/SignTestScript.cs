using UnityEngine;
using System.Collections;

public class SignTestScript : MonoBehaviour
{
    public TextMesh signText;

    // Use this for initialization
    void Start()
    {
        //set the sign text
        signText.text = "Level 1";
    }

    // Update is called once per frame
    void Update()
    {
        signText.GetComponent<MeshRenderer>().sortingLayerName = "Interactables Layer";
    }
}
