using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_sc : MonoBehaviour
{
    // public GameObject Nica;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        NicaMove();
    }

    private void NicaMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(-5.2f, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 28);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(4.6f, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, -28);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}