using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BacktoMenu : MonoBehaviour
{
    public void Return_To_Menu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
