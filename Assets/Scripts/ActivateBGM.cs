using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateBGM : MonoBehaviour
{
    public AudioSource source;
    
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;

    public Text text;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(100f, 100f, 0f) * Time.deltaTime);
    }

    void OnTriggerEnter()
    {
        if(this.name == "ActivateBGM1")
        {
            text.text = "Touhou soundtrack initiated";
            source.clip = music1;
        }
        else if (this.name == "ActivateBGM2")
        {
            text.text = "Pepsi Man OST initiated";
            source.clip = music2;
        }
        else if (this.name == "ActivateBGM3")
        {
            text.text = "Hotline Miami initiated";
            source.clip = music3;
        }
        DisplayText();
        StartCoroutine(ClearText());
        source.Stop();
        source.PlayOneShot(source.clip);
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
}
