using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSounds : MonoBehaviour
{
    public AudioSource source;
    public AudioClip click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            source.clip = click;
            source.PlayOneShot(source.clip);
        }
    }
}
