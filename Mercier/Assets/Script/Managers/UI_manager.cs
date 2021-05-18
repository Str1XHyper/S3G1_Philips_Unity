using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text;

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

    //Old
    [Header("Old")]
    [SerializeField] private TMP_Text pointText;
    [SerializeField] private TMP_Text starText;
    [SerializeField] private TMP_Text questionText;

    //New
    [Space]
    [Header("Phone")]
    [SerializeField] private GameObject questionGroup;
    [SerializeField] private TMP_Text correctAnswerText;
    [SerializeField] private TMP_InputField answerInput;
    [SerializeField] private GameObject InputGroup;


    //Feedback
    [Space]
    [Header("Feedback")]
    [SerializeField] private GameObject FeedbackGroup;
    [SerializeField] private GameObject FeedbackCorrectBackground;

    void Start()
    {

    }

    public void UpdateText()
    {
        pointText.text = "Points: " + TurnManager.instance.CurrentPlayerGroup.CurrentMoneyAmount.ToString();
        starText.text = "Stars: " + TurnManager.instance.CurrentPlayerGroup.CurrentAmountOfStars.ToString();
    }

    public void UpdateText(ScoreResponse[] scoreResponses)
    {
        //TODO: TIJN fix ff dat hier scores afgehandeld worden per persoon
        StringBuilder stringBuilder = new StringBuilder();
        foreach (ScoreResponse response in scoreResponses)
        {
            stringBuilder.Append(response.playerId);
            stringBuilder.Append(response.Points);
            stringBuilder.Append(response.Stars);
        }
    }

    public void UpdateQuestion(string questionText)
    {
        this.questionText.text = questionText;
    }

    public void ShowQuestionBox(Question question)
    {
        Debug.Log("trigger UI_Manager");

        Destroy(questionGroup);

        Debug.Log("trigger UI_Manager 2");


        //questionText.text = question.question;
        //correctAnswerText.text = question.answer;
        //correctAnswerText.text = "test please work plz";
        //questionGroup.gameObject.SetActive(true);
        //InputGroup.gameObject.SetActive(true);
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
        }
        else
        {
            // Show Incorrect Feedback
            FeedbackCorrectBackground.SetActive(false);
        }


        answerInput.text = "";
        Debug.Log(answer);
    }

    public void CloseIphone()
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
