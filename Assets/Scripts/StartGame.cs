using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public void Start_Game()
    {
        StartCoroutine(Wait());
    }

    public void Hover()
    {
        source.clip = clip;
        source.PlayOneShot(source.clip);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Loading");
    }
}
