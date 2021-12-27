using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Peaks()
    {
        SceneManager.LoadScene("The Peaks of prosperity");
    }

    public void Cave()
    {
        SceneManager.LoadScene("The Cave of content");
    }

    public void Blossoms()
    {
        SceneManager.LoadScene("The Blossoms of beauty");
    }
}
