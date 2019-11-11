using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_Movement : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        //exit the drone cam and unspawn it.
        Debug.Log("Collided");
    }
    public float speed;
   
    //public float rotation;
    public float ascent = 5;

    private GameObject[] rotorBlades;
  
   
    private float RotorSpeed = 10;
    private Rigidbody rb;
    //float tiltAngle = -60.0f;
    private GameObject droneMove;

    public float rotationSpeed = 50f; //for rotating the drone itself based on movement
  
    private float x;
    private float z;

    public float turnSpeed = 1; //FOr turning the drone left or right on the Y axis. Different from above stuff

    void Start()
    {
        rotorBlades = GameObject.FindGameObjectsWithTag("RotorPart");


 
        droneMove = GameObject.Find("DroneMove");

        rb = droneMove.GetComponent<Rigidbody>();

        x = 0.0f;
        z = 0.0f;
        
        rotationSpeed = 30.0f;

    }



    void FixedUpdate()
    {


        //Movement stuff below

        foreach (GameObject r in rotorBlades)
        {
            r.transform.Rotate(0, 0, RotorSpeed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
           droneMove.transform.Translate(0, ascent * Time.deltaTime, 0);
         
            RotorSpeed = 100;
        }
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
            droneMove.transform.Translate(0, -ascent * Time.deltaTime, 0);
            RotorSpeed = 20;
        }


        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;

        droneMove.transform.Translate(horizontal, 0, vertical); //all movement


        //Rotation stuff below
        z = 0; //reset
            
        if (horizontal!= 0 && (z < 30.0f && z > -30.0f))
        {
            z += rotationSpeed * -horizontal;
        }
        
        x = 0; //reset
        
        if(vertical!=0 && (x<30.0f && x > -30.0f)){
            x += rotationSpeed * vertical;
        }
        

        transform.localRotation = Quaternion.Euler(x, 0, z);


        if (Input.GetKey(KeyCode.Z))
        {
            droneMove.transform.Rotate(0, -turnSpeed, 0);
            
        }
        else if (Input.GetKey(KeyCode.X))
        {
            droneMove.transform.Rotate(0, turnSpeed, 0);
        }


    }
}
