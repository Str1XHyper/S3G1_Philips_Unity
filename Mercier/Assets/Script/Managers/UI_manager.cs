using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text;
using System.Linq;

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
    [SerializeField] private Button buttonSend;
    [SerializeField] private Button buttonContinue;
    [SerializeField] private Button buttonStart;
    [SerializeField] private TMP_Text correctAnswerText;
    [SerializeField] private TMP_InputField answerInput;
    [SerializeField] private GameObject InputGroup;

    //Feedback
    [Space]
    [Header("Feedback")]
    [SerializeField] private GameObject FeedbackGroup;
    [SerializeField] private GameObject FeedbackCorrectBackground;

    //Leaderboard
    [Space]
    [Header("Leaderboard")]
    [SerializeField] private TMP_Text leaderboardPointText;
    [SerializeField] private TMP_Text leaderboardStarText;
    [Space]
    [SerializeField] private GameObject topThree;

    //private List<> playersRanked;

    private bool startGameButtonActive = true;
    private bool gameAlreadyStarted = false;

    void LateUpdate()
    {
        if (!gameAlreadyStarted)
        {
            if (!startGameButtonActive)
            {
                gameAlreadyStarted = true;
                buttonStart.gameObject.SetActive(false);
            }
        }
    }

    public void UpdateText()
    {
        leaderboardPointText.text = TurnManager.instance.CurrentPlayerGroup.CurrentMoneyAmount.ToString();
        leaderboardStarText.text = TurnManager.instance.CurrentPlayerGroup.CurrentAmountOfStars.ToString();

        SocketCaller.instance.RequestScore();
    }

    public void UpdateText(Scores scores)
    {

        List<ScoreResponse> listScoreResponse = new List<ScoreResponse>();
        foreach (ScoreResponse response in scores.scoreResponses)
        {
            listScoreResponse.Add(response);
            
            Debug.Log("Points: " + response.Points);
        }
        List<ScoreResponse> scoreListSorted = listScoreResponse.OrderByDescending(response => response.Stars).ThenByDescending(response => response.Points).ToList();

        topThree.GetComponent<LeaderBoard>().UpdateTopThree(scoreListSorted);
    }

    public void UpdateQuestion(string questionText)
    {
        this.questionText.text = questionText;
    }

    public void ShowQuestionBox(Question question)
    {
        UnityThread.executeInLateUpdate(() => { 
            questionGroup.SetActive(true);
            InputGroup.gameObject.SetActive(true);

            questionText.gameObject.SetActive(true);
            questionText.text = question.question;
            
            correctAnswerText.text = question.answers[0].answer;
        });
    }

    public void StartGame()
    {
        SocketCaller.instance.StartGame(new StartGameMessage("1"));
        HideStartButton();
    }

    public void HideStartButton()
    {
        startGameButtonActive = false;
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

        
        UI_manager.instance.UpdateText();

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
