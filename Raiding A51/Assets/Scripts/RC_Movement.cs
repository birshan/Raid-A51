using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_Movement : MonoBehaviour
{

    public float speed;
    public float maxSpeed;
    public float acceleration;
    public float rotation;
    public float jumpForce;
    private GameObject left;
    private GameObject right;
    private float wheelSpeed = 5;
    private Rigidbody rb;

    void Start()
    {
        left = GameObject.Find("RCLeftWheel");
        right = GameObject.Find("RCRightWheel");
        rb = GetComponent<Rigidbody>(); //rb only used for RC car jump in this script
    }



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, jumpForce, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            left.transform.Rotate(wheelSpeed, 0, 0);
            right.transform.Rotate(wheelSpeed, 0, 0);
            if (speed < maxSpeed)
            {
                speed += acceleration;

            }

        }

        else
        {
            if (speed > 0)
            {
                speed -= acceleration;
                left.transform.Rotate(wheelSpeed, 0, 0);
                right.transform.Rotate(wheelSpeed, 0, 0);
            }
        }


        transform.position += transform.forward * Time.deltaTime * speed;


        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotation, 0);
            left.transform.Rotate(wheelSpeed, 0, 0);
            right.transform.Rotate(-wheelSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotation, 0);
            left.transform.Rotate(-wheelSpeed, 0, 0);
            right.transform.Rotate(wheelSpeed, 0, 0);
        }
    }

}