using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOut : MonoBehaviour
{
    //this tells us if the lamp is on or off
    public bool lampOn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //vector for the position of the shadow, which is relative to its parent
        Vector3 pos = transform.localPosition;

        //if the space key is pressed, it switches the light's variable, making it alter between two positions (as booleans do)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lampOn = !lampOn;
        }

        //if the light is on, its position stays at 0, which will be local to the lamp's swinging
        if(lampOn == true)
        {
            
            pos.x = 0;
        }

        if(lampOn == false)
        {
            //if the light is off, the shadow moves to the right a bit

            pos.x = 30;
        }

        //then the LOCAL position updates with the new spot
        transform.localPosition = pos;
    }
}
