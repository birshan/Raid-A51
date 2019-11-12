using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public static float CameraSensitivity; //create a variable here
   
    void Start()
    {
        CameraSensitivity = Variables.CameraSensitivity; // set the value here
    }

    // Update is called once per frame
    void Update()
    {
        var y = Input.GetAxis("Mouse Y") * Time.deltaTime * CameraSensitivity; //the value is used here
        transform.Rotate(-y, 0, 0);
        Mathf.Clamp(0,-90,90);

    }
}
