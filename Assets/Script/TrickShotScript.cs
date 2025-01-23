using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class TrickShotScript : MonoBehaviour
{
    public float speed = 10f;

    public float jumpspeed = 3;
    
    public AnimationCurve arc;
    [Range(0, 1)]
    public float t;

    public bool jumpUp = false;
    public bool fallDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //--------------------------------------------------------------------------
        //this vector is equal to the current position.
        Vector2 pos = transform.position;

        //the y component of pos changes depending on the value of t relative to a selected curve.
        pos.y = arc.Evaluate(t);
        
        //the x component of pos changes constantly based on a given speed, mitigated by deltaTime.
        pos.x += speed * Time.deltaTime;

        //then, we change the whole position vector to match the pos vector, whose components we can change individually.
        transform.position = pos;

        //--------------------------------------------------------------------------



        //--------------------------------------------------------------------------

        //this vector is equal to the position of the square in the space of the screen.
        Vector2 squareInScreenSpace = Camera.main.WorldToScreenPoint(transform.position);
        
        //if the square hits the edges of the screen, it bounces back.
        if (squareInScreenSpace.x < -10 || squareInScreenSpace.x > Screen.width)
        {
            speed = speed * -1;
        }

        //--------------------------------------------------------------------------



        //--------------------------------------------------------------------------

        //if the spacebar is pressed, start the jump timer.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpUp = true;
        }

        //if the timer has started, increase t, which moves us along the curve. if it reaches one, start the second phase of the timer.
        if (jumpUp)
        {
            t += Time.deltaTime*jumpspeed;

            if (t >= 1)
            {
                jumpUp = false;
                fallDown = true;
            }
        }
        
        //the second phase of the timer, which brings t back down.
        if(fallDown)
        {
            t -= Time.deltaTime*jumpspeed;

            if (t <= 0)
            {
                t = 0;
                fallDown = false;
            }
        }
        

      
    }
}
