using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_manager : MonoBehaviour
{
    #region SingleTon
    public static UI_manager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    [SerializeField] private TMP_Text pointText;
    [SerializeField] private TMP_Text starText;
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private TMP_InputField answerInput;
    [SerializeField] private GameObject questionGroup;
    [SerializeField] private Button button;


    void Start()
    {
        button.onClick.AddListener(() => SendAnswer());
    }

    public void UpdateText()
    {
        pointText.text = "Points: " + TurnManager.instance.CurrentPlayerGroup.CurrentMoneyAmount.ToString();
        starText.text = "Stars: " + TurnManager.instance.CurrentPlayerGroup.CurrentAmountOfStars.ToString();
    }

    public void UpdateQuestion(string questionText)
    {
        this.questionText.text = questionText;
    }

    public void ShowQuestionBox(string question)
    {
        questionText.text = question;
        questionGroup.gameObject.SetActive(true);
        
        Debug.Log("trigger UI_Manager");
    }

    public void SendAnswer()
    {
        questionGroup.gameObject.SetActive(false);
        string answer = answerInput.text;

        //Send Answer To Back End
        QuestionManager.instance.SendAnswer(answer);
        answerInput.text = "";
        Debug.Log(answer);
    }

    public TMP_Text PointText { get => pointText; private set => pointText = value; }
    public TMP_Text StarText { get => starText; private set => starText = value; }
    public TMP_Text QuestionText { get => questionText; private set => questionText = value; }
    public TMP_InputField AnswerInput { get => answerInput; private set => answerInput = value; }
}
