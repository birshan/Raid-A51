using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static float MouseSensitivity; //create a variable here
    public static float MoveSpeed;


    void Start()
    {
        MouseSensitivity = Variables.MouseSensitivity; //pull it up here
        MoveSpeed = Variables.MoveSpeed; //set the value from the Variables script here
    }

    void Update()
    {

        var x = Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensitivity;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * MoveSpeed;
        var lr = Input.GetAxis("Horizontal") * Time.deltaTime * MoveSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        transform.Translate(lr, 0, 0);

    } 
}
