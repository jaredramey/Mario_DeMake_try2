using UnityEngine;
using System.Collections;

/*
 *UPDATE:
 *CODE IS NOT BEING USED
 */

public class BossHealthBar : MonoBehaviour
{
    /*Code created by watermy: http://answers.unity3d.com/questions/306447/c-health-bar.html */
    //Mildly modified

    //Set Max health and what the current health is for later use
    public int maxHealth = 100;
    public int curHealth = 100;

    //Get the textures used for health bar
    public Texture2D bgImage;
    public Texture2D fgImage;

    public float healthBarLength;


    // Use this for initialization
    void Start()
    {
        healthBarLength = Screen.width / 2;
        bgImage.wrapMode = TextureWrapMode.Repeat;
        bgImage.Apply();

        fgImage.wrapMode = TextureWrapMode.Repeat;
        fgImage.Apply();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnGUI()
    {
        //Create One group to contain both images
        //Adjust first 2 cords for replacement
        GUI.BeginGroup(new Rect((Screen.width - (Screen.width-150)), (Screen.height-(Screen.height-400)), healthBarLength, 32));

        //Draw background Image
        GUI.Box(new Rect(0, 0, healthBarLength, 32), bgImage);

        //create a second group which will be clipped
        //want to clip, not scale
        GUI.BeginGroup(new Rect(0, 0, curHealth / maxHealth * healthBarLength, 32));

        //Draw foreground image
        GUI.Box(new Rect(0, 0, healthBarLength, 32), fgImage);

        //End both groups
        GUI.EndGroup();

        GUI.EndGroup();
    }

    public void AddjustCurrentHealth(int adj)
    {
        curHealth = gameObject.GetComponentInChildren<BossController>().health;

        healthBarLength = (Screen.width/2) * (curHealth / maxHealth);
    }
}
