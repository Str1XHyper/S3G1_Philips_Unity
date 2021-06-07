using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    private Animator animator;

    public void Start()
    {
        animator = camera.GetComponent<Animator>();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    public void LoadSettings()
    {
        animator.ResetTrigger("MenuClick");
        animator.SetTrigger("SettingsClick");
    }

    public void LoadMenu()
    {
        animator.ResetTrigger("SettingsClick");
        animator.SetTrigger("MenuClick");
    }
}
