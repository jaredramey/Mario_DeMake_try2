using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    /*Following a tutorial on smooth camera control
     link to tutorial: https://www.youtube.com/watch?v=u67fbxe8xxY */

    //Variables for camera control
    //Camera cam = Camera.main;

    public Transform Player;

    public Vector2 Margin, Smoothing;

    public BoxCollider2D Bounds;

    private Vector3 _min, _max;

    public bool IsFollowing { set; get; }

    // Use this for initialization
    void Start()
    {
        _min = Bounds.bounds.min;
        _max = Bounds.bounds.max;
        IsFollowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;

        if(IsFollowing)
        {
            //If following then get the Abs pos of the camera so it knows where to be
            //If camera is outside the margine specified then smooth it so it doesn't go outside of it
            if(Mathf.Abs(x - Player.position.x) > Margin.x)
            {
                x = Mathf.Lerp(x, Player.position.x, Smoothing.x * Time.deltaTime);
            }

            //If camera is outside the margine specified then smooth it so it doesn't go outside of it
            if(Mathf.Abs(y - Player.position.y) > Margin.y)
            {
                y = Mathf.Lerp(y, Player.position.y, Smoothing.y * Time.deltaTime);
            }
        }

        //Get half the width of the camera for the x-axis
        var cameraHalfWidth = Camera.main.orthographicSize * ((float) Screen.width/ Screen.height);

        //clamp camera on x-axis
        x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
        //clamp camera on y-axis
        y = Mathf.Clamp(y, _min.y + Camera.main.orthographicSize, _max.y - Camera.main.orthographicSize);

        transform.position = new Vector3(x, y, transform.position.z);

    }
}
