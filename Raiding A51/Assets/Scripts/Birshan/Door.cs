using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private float y;

    public float rotationSpeed = 10f;
    private bool clicked;
    private bool opened;
    void OnMouseDown()
    {
         clicked = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        y = 0.0f;
        clicked = false;
        rotationSpeed = 10.0f;
        opened = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked == true && opened ==false)
        {
            if (y < 90.0f)
            {
                y += rotationSpeed;
            }
            else
            {
                clicked = false;
                opened = true;
            }
            
            
            transform.parent.transform.localRotation = Quaternion.Euler(0, y, 0);
        }
        if(clicked == true && opened == true)
        {
            if (y > 0.0f)
            {
                y += -rotationSpeed;
            }
            else
            {
                clicked = false;
                opened = false;
            }

            transform.parent.transform.localRotation = Quaternion.Euler(0, y, 0);
        }

       
       
    }
}
