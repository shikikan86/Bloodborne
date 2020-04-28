using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    public GameObject barrier;
    public AudioSource source;
    public AudioClip music;
    public AudioClip SE;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(100f, 100f, 0f) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(other.name == "Player")
        {
            source.clip = SE;
            source.PlayOneShot(source.clip);

            if (this.name == "To Old Yharnam")
            {
                barrier.transform.position += new Vector3(0f, 0f, 3.2f);
                this.gameObject.SetActive(false);
            }

            if (this.name == "SpeedyBoyEE")
            {
                source.Stop();
                source.clip = music;
                source.PlayOneShot(source.clip);
                Player.speedy = true;
                this.gameObject.SetActive(false);
            }

            if (this.name == "To Forbidden Woods")
            {
                SceneManager.LoadScene("GameFinish");
            }

        }

        
        
    }
}
