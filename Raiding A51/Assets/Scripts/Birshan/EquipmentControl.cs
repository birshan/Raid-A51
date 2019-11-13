using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentControl : MonoBehaviour
{
    public GameObject[] equipment;
    // Start is called before the first frame update
    public int current = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            current = 0;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            current = 1;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            current = 2;
        }


        for(int i = 0; i<equipment.Length; i++)
        {
            if(i == current)
            {
                equipment[i].SetActive(true);
            }
            else
            {
                equipment[i].SetActive(false);
            }
        
        }
    }
}
