using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordText : MonoBehaviour
{
    public Text text;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
        image.enabled = false;

    }

    void DisplayText()
    {
        text.enabled = true;
        image.enabled = true;
        text.text = "A Password Has Been Discovered!";
    }

    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(3f);
        text.enabled = false;
        image.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            DisplayText();
            StartCoroutine(ClearText());
        }

    }
}
