using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LampSwing : MonoBehaviour
{

    public AnimationCurve swing;

    //public Transform start;
    //public Transform end;

    [Range(0,1)]
    public float t;

    public float direction = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    //this is a simple function that makes a circle (the axis point) spin
        Vector3 rot = transform.eulerAngles;


        //t represents where we are on the curve
        //limit can be either negative one or positive one, meaning that t can go up or down the curve
        //deltaTime is in there to smooth things out
        t += direction * Time.deltaTime;

        //Vector2 test = (-33, 33);

        //every frame, a value is either added or subtracted from the z rotation of the axis point
        //the value is based on the animation curve to give the illusion of a swinging motion, multiplied by the direction (-1 or 1)
        
        rot.z += direction * swing.Evaluate(t);

        //some failed lines of code as I was trying to make this thing work >:[
        //transform.eulerAngles = Vector2.Lerp(-33, 33, swing.Evaluate(t));
        //rot.z += Mathf.Lerp((direction * swing.Evaluate(t)), -0.7f, 0.7f);
        // rot.z += limit;

        //if t reaches the upper end of its range, the direction flips
        if (t >= 1)
        {
            t = 1;
            direction *= -1;
            //rot.z = 37;
        }

        if(t <= 0)
        {
            t = 0;
            direction *= -1;
            //rot.z = -37;
        }

        /* if (t >= 1 || t <= 0)
         {
             limit = limit * -1;
         }
 */
        transform.eulerAngles = rot;
    }
}
