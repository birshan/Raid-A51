using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    private LineRenderer lr;
    Vector3 defaultlaser = new Vector3(0, 0, 0);
    public float startWidth = 0.1f;
    public float endWidth = 0.1f;

    //for initialization

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.GetPosition(0);
        lr.SetWidth(startWidth, endWidth);
        

    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);

        defaultlaser = transform.position;
        defaultlaser.z = 200f;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
        }

        else lr.SetPosition(1, defaultlaser);


    }
}
