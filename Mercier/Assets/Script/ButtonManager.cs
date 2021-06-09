using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    private Animator animator;

    [SerializeField] private GameObject inputField;
    [SerializeField] private GameObject startGameButton1;
    [SerializeField] private GameObject startGameButton2;

    [SerializeField] private GameObject settingsButton;


    public void Start()
    {
        animator = camera.GetComponent<Animator>();
    }

    public void StartGame()
    {
        inputField.SetActive(true);
        startGameButton1.SetActive(false);
        startGameButton2.SetActive(true);
        settingsButton.SetActive(false);
    }

    public void LoadNextLevel()
    {
        PlayerPrefs.SetString("Username", inputField.GetComponentInChildren<TMP_InputField>().text);
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
