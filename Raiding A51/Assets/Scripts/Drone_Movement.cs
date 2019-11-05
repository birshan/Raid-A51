using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Movement : MonoBehaviour
{
    public float speed;
    public float maxSpeed = 1000;
    public float acceleration=30;
    public float sideWaysSpeed = 5;
    public float rotation;
    public float ascent = 5;
    public float controlledDescent = 0.1f;
    private GameObject[] rotorBlades;
    private float zRotation;
    private float xRotation;
   
    private float RotorSpeed = 10;
    private Rigidbody rb;
    float tiltAngle = -60.0f;

    void Start()
    {
        rotorBlades = GameObject.FindGameObjectsWithTag("RotorPart");

        rb = GetComponent<Rigidbody>();

        zRotation = transform.rotation.z;
        xRotation = transform.rotation.x;
        
    }



    void FixedUpdate()
    {

        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle; //will tilt the disk to turning side


        Quaternion cube = Quaternion.Euler(tiltAroundZ, 0, tiltAroundZ);

        transform.rotation = Quaternion.Slerp(transform.rotation, cube, Time.deltaTime);

        foreach (GameObject r in rotorBlades)
        {
            r.transform.Rotate(0, 0, RotorSpeed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
           // this.transform.Translate(0, ascent, 0);
          rb.AddForce(0, ascent * Time.deltaTime, 0);
            RotorSpeed = 100;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(0, controlledDescent * Time.deltaTime, 0);
            RotorSpeed = 20;
        }
        if (Input.GetKey(KeyCode.W))
        {
            RotorSpeed = 100;
            if (speed < maxSpeed)
            {
                speed += acceleration;

            }
          //  rb.AddForce(0, 0, speed * Time.deltaTime);

        }

        else
        {
            if (speed > 0)
            {
                speed -= acceleration;
                RotorSpeed = 20;
             
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            RotorSpeed = 100;
            if (speed > -maxSpeed)
            {
                speed -= acceleration;

            }
            //  rb.AddForce(0, 0, speed * Time.deltaTime);

        }
        else
        {
            if (speed < 0)
            {
                speed += acceleration;
                RotorSpeed = 20;

            }
        }


        transform.position += transform.forward * Time.deltaTime * speed;


        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(sideWaysSpeed * Time.deltaTime, 0, 0);
          // transform.Rotate(0, rotation, 0);
            //left.transform.Rotate(wheelSpeed, 0, 0);
            //right.transform.Rotate(-wheelSpeed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-sideWaysSpeed * Time.deltaTime, 0, 0);
            // transform.Rotate(0, -rotation, 0);
            // left.transform.Rotate(-wheelSpeed, 0, 0);
            //right.transform.Rotate(wheelSpeed, 0, 0);
        }

    }
}
