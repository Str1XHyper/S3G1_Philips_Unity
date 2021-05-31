using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void LoadNextLevel()
    {
        Console.WriteLine(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Console.WriteLine(SceneManager.GetActiveScene().name);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
