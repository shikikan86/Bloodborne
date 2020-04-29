using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHunter : MonoBehaviour
{
    public Text text;
    public Image image;
    public AudioSource source;
    public AudioSource source2;
    public AudioClip clip;
    public Image YouDied;

    void Start()
    {
        YouDied.enabled = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.name == "Player")
        {
            StartCoroutine(DisplayText());
        }
        
    }

    IEnumerator DisplayText()
    {
        //Plays out a sequence that simulates a death and sends you back to the main menu
        source2.Stop();
        text.text = "My name Alfred. I kill you now.";
        text.enabled = true;
        image.enabled = true;
        yield return new WaitForSeconds(3f);
        source.Stop();
        source.clip = clip;
        source.PlayOneShot(source.clip);
        yield return new WaitForSeconds(1f);
        YouDied.enabled = true;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("TitleScreen");
    }

}
