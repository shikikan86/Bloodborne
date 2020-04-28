using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public bool activated = false;
    public GameObject barrier;
    public Vector3 startPosition; //for the gate that is associated with the switch
    public Vector3 endPosition;
    public float lerpTime;
    public float currentLerpTime;


    public AudioSource source;
    public AudioClip gate;

    void Start()
    {
        //Positions for the gate when it moves
        lerpTime = 4f;
        currentLerpTime = 0f;
        startPosition = barrier.transform.position;
        endPosition = barrier.transform.position + new Vector3(0f, 0f, 2.9f);
    }

    void Update()
    {
        //If activated is true, the gate will move, granting access.
        if (activated)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float temp = currentLerpTime / lerpTime;
            barrier.transform.position = Vector3.Lerp(startPosition, endPosition, temp);
        }
        
    }

    void OnCollisionEnter()
    {
        //'activated' prevents the switch from moving multiple times
        
        if (!activated)
        {
            activated = true;
            transform.Rotate(35f, 0f, 0f);
            //Play a sound here 
            source.clip = gate;
            source.PlayOneShot(source.clip);
        }


    }
}
