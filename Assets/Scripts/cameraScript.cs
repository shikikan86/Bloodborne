using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Vector3 startposition;
    
    void Start()
    {
        startposition = transform.position;
    }

    void Update()
    {
        //Moves the camera angle with left and right arrow
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-1f, 0f, 0f);
            transform.Translate(0f, -0.1f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(1f, 0f, 0f);
            transform.Translate(0f, 0.1f, 0f);
        }

    }
}
