using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Password : MonoBehaviour
{
    public GameObject barrier;


    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            //barrier.transform.position += new Vector3(0f, 0f, 3.2f);
            Player.passwordKnown = true;
            this.gameObject.SetActive(false);
            
        }

    }
}
