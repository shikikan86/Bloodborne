using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//This script only exists because a sound can't be played if an object is destroyed (picked up by player), so it's here to make sure post-deletion commands are still executed
public class KeyText : MonoBehaviour
{
    public Text text;
    public Image image;
    public bool active;
    public int triggerEnterCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
        image.enabled = false;
        active = true;
        //transform.Rotate(new Vector3(100f, 100f, 0f) * Time.deltaTime);

    }

    void Update()
    {
        if(active)
            transform.Rotate(new Vector3(100f, 100f, 0f) * Time.deltaTime);
        else
            transform.Rotate(new Vector3(0f, 0f, 0f) * Time.deltaTime);
    }

    void DisplayText()
    {
        text.enabled = true;
        image.enabled = true;
        
    }

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(3f);
        text.enabled = false;
        image.enabled = false;
    }
    
    void OnTriggerEnter(Collider other)
    {
        triggerEnterCount++;

        if (other.name == "Player")
        {
            if(this.name == "To Old Yharnam Text Holder")
            {
                text.text = "A New Path Has Been Unlocked!";
                active = false;
                DisplayText();
                StartCoroutine(ClearText());
                transform.Rotate(new Vector3(0f, 0f, 0f) * Time.deltaTime);
            }

            //I should make another script for the Hemwick object, but this is what laziness looks like
            //Get used to it :)
            else if (this.name == "To Hemwick Text Holder")
            {
                if(triggerEnterCount >= 2)
                {
                    text.text = "NO MEANS NO";
                   
                }
                else
                {
                    text.text = "This path would normally lead to Hemwick, but the developer was too lazy to put that in the game";
                }
                DisplayText();
                StartCoroutine(ClearText());     

            }

            else if(this.name == "SpeedyBoyText")
            {
                text.text = "You feel... faster somehow";
                DisplayText();
                StartCoroutine(ClearText());
            }

        }
           
    }
}
