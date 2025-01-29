using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Paddle : MonoBehaviour

{
    public Vector3 mpos;
    public Vector3 apos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //I followed video 1.4 to help with this a bit
        //this gets the position of the mouse on the screen and translates it into its relative position in worldspace
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //I don't want the paddle to be able to spin around entirely so I have to limit it
        //the rotation of this axis point is based on the x and y position of the mouse variable
        //so I'm going to lerp both the x and the y to the desired limit, then reassign those new values to the mouse
        float mx = Mathf.Lerp(1, 3, mouse.x);
        float my = Mathf.Lerp(-0.5f, 5, mouse.y);
        mouse.x = mx;
        mouse.y = my;
        

        //now I'm making a new vector that represents the line between the axis and the mouse
        Vector2 direction = mouse - transform.position;

        //the y axis of the axis point follows the direction vector
        transform.up = direction;

        //this is just a test for viewing what the mouse and axis values are in the inspector
        mpos = mouse;
        apos = transform.up;
    }
}
