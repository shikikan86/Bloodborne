using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalBarrier : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public bool activated = false;
    public Vector3 startPosition; //for the wall that is associated with the switch
    public Vector3 endPosition;
    public float lerpTime = 5f;
    public float currentLerpTime = 0;
    public Text text;
    public Image image;

    void Start()
    {
        //Positions for the gate when it moves
        startPosition = transform.position;
        endPosition = transform.position + new Vector3(0f, 0f, 2.9f);
        text.enabled = false;
        image.enabled = false;
    }

    void Update()
    {
        if (activated)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float temp = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, temp);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            //open gate if the player has the password, otherwise don't
            if (Player.passwordKnown)
            {
                activated = true;
                DisplayText1();
                source.clip = clip;
                source.PlayOneShot(source.clip);
                StartCoroutine(ClearText());
                Debug.Log("Password");

            }
            else
            {
                DisplayText2();
                StartCoroutine(ClearText());
                Debug.Log("No Password");
            }
        }
    }

    void DisplayText1()
    {
        text.enabled = true;
        image.enabled = true;
        text.text = "\"The Password... Accepted\"";


    }

    void DisplayText2()
    {
        text.enabled = true;
        image.enabled = true;
        text.text = "\"The Password...\"";


    }

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(3f);
        text.enabled = false;
        image.enabled = false;
    }
}
