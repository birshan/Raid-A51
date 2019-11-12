using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    public float MouseSensitivity = 100f;

    
    public float MoveSpeed = 10f;


    void Start()
    {
        
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
