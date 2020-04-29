using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Initializations
    public float speed;
    public static bool speedy;
    public static bool passwordKnown;
    public float turnSpeed;
    public AudioClip bgm;
    public AudioSource source;


    void Start()
    {
        passwordKnown = false;
        speedy = false;
        speed = 5f;
        turnSpeed = 2.5f;
        source = GetComponent<AudioSource>();
        source.clip = bgm;
        source.PlayOneShot(source.clip);
    }

    void Update()
    {
        //Quit Game
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScreen");
        }


        //Basic WASD or arrow key movement
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
        transform.Translate(0f, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);

        //Rotate
        if (Input.GetKey("a"))
        {
            transform.Rotate(0f, 0f, turnSpeed);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(0f, 0f, -turnSpeed);
        }

        //Basic Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!speedy)
            {
                speed = 10f;
                turnSpeed = 2f;
            }
            else
            {
                speed = 20f;
                turnSpeed = 3f;
            }
            
        }
        else
        {
            if (!speedy)
            {
                speed = 5f;
            }
            else
            {
                speed = 10f;
            }
            
        }


    }

}
