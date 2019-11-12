using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private float yRotation;
    public float RotationSpeed = 0.5f;
    public float DegreeOfRotation;

    // Start is called before the first frame update
    void Start()
    {
        yRotation = this.transform.rotation.eulerAngles.y;//transform with lower case refers to this game object
        Debug.Log(yRotation);

    }

    // Update is called once per frame
    void Update()
    {

        //transform.Rotate(0, RotationSpeed, 0);
        //Debug.Log("Current Rotation " + transform.rotation.y + "<" + yRotation + DegreeOfRotation);

        //Debug.Log(transform.rotation.eulerAngles.y +"vs"+ DegreeOfRotation +"+"+ yRotation);
        Debug.Log("yRotation =" + yRotation + this.gameObject.name);
        if (this.transform.rotation.eulerAngles.y > DegreeOfRotation + yRotation)
        {
            // Debug.Log("<<<<<<<<<<   ENDED    >>>>>>>>>>");
            RotationSpeed = -RotationSpeed;

        }
        if (this.transform.rotation.eulerAngles.y < -DegreeOfRotation + yRotation) //Always keeps it turning between the degree of rotation.
        {
            RotationSpeed = -RotationSpeed;
        }



        this.transform.Rotate(0, RotationSpeed, 0, Space.Self);


    }


}