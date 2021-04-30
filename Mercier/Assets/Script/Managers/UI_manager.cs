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
    [SerializeField] private Button buttonSend;
    [SerializeField] private Button buttonContinue;
    [SerializeField] private TMP_Text correctAnswerText;
    [SerializeField] private GameObject InputGroup;
    [SerializeField] private GameObject FeedbackGroup;
    [SerializeField] private GameObject FeedbackCorrectBackground;
    [SerializeField] private GameObject FeedbackIncorrectBackground;

    void Start()
    {
        buttonSend.onClick.AddListener(() => SendAnswer());
        buttonContinue.onClick.AddListener(() => CloseIphone());
    }

    public void UpdateText()
    {
        pointText.text = "Points: " + TurnManager.instance.CurrentPlayerGroup.CurrentMoneyAmount.ToString();
        starText.text = "Stars: " + TurnManager.instance.CurrentPlayerGroup.CurrentAmountOfStars.ToString();
    }

    public void UpdateText(ScoreResponse scoreResponse)
    {
        //TODO: TIJN fix ff dat hier scores afgehandeld worden per persoon
    }

    public void UpdateQuestion(string questionText)
    {
        this.questionText.text = questionText;
    }

    public void ShowQuestionBox(Question question)
    {
        questionText.text = question.question;
        correctAnswerText.text = question.answer;
        questionGroup.gameObject.SetActive(true);
        InputGroup.gameObject.SetActive(true);
        Debug.Log("trigger UI_Manager");
    }

    public void SendAnswer()
    {
        InputGroup.gameObject.SetActive(false);
        FeedbackGroup.gameObject.SetActive(true);

        string answer = answerInput.text;

        
        if(QuestionManager.instance.SendAnswer(answer))
        {
            // Show Correct Feedback
            FeedbackCorrectBackground.SetActive(true);
            FeedbackIncorrectBackground.SetActive(false);
        }
        else
        {
            // Show Incorrect Feedback
            FeedbackIncorrectBackground.SetActive(true);
            FeedbackCorrectBackground.SetActive(false);
        }


        answerInput.text = "";
        Debug.Log(answer);
    }

    private void CloseIphone()
    {
        FeedbackGroup.gameObject.SetActive(false);
        questionGroup.gameObject.SetActive(false);
    }

    public TMP_Text PointText { get => pointText; private set => pointText = value; }
    public TMP_Text StarText { get => starText; private set => starText = value; }
    public TMP_Text QuestionText { get => questionText; private set => questionText = value; }
    public TMP_InputField AnswerInput { get => answerInput; private set => answerInput = value; }
    public TMP_Text CorrectAnswerText { get => correctAnswerText; private set => correctAnswerText = value; }
}
