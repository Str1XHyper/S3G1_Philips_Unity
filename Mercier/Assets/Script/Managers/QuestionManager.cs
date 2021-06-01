using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    private const float IntervalTime = 0.5f;
    private const float MaxWaitTime = 3f;

    #region SingleTon
    public static QuestionManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }
    #endregion
    private Question question = new Question();
    private List<Question> allQuestions = new List<Question>();

    private void Start()
    {
        SetupQuestionList();
    }

    #region QuestionLoader

    private void SetupQuestionList()
    {
        StartCoroutine(LoadList());
    }

    private IEnumerator LoadList()
    {
        Question[] questions = BackEndCommunicationManager.instance.questions;

        float currentWaitTime = 0f;

        while (questions.Length <= 0)
        {
            questions = BackEndCommunicationManager.instance.questions;

            currentWaitTime += Time.deltaTime;

            yield return new WaitForSeconds(IntervalTime);

            if (currentWaitTime >= MaxWaitTime)
            {
                //Waiting to long
                break;
            }
        }

        foreach (Question question in questions)
        {
            allQuestions.Add(question);
        }
    }

    #endregion

    public bool SendAnswer(string answer)
    {
        AnsweredQuestionMessage answerQuestionMessage = new AnsweredQuestionMessage(GroupsManager.instance.GetLocalPlayer().GroupPawn.PlayerID, answer);
        SocketCaller.instance.AnsweredQuestion(answerQuestionMessage);
        if (answer == this.Question.answers[0].answer)
        {
            return true;
        }
        else
        {
            return false;
        }        
    }

    public void AskQuestion(Question question)
    {
        this.Question = question;
        UI_manager.instance.ShowQuestionBox(question);
    }
    public Question Question { get => question; private set => question = value; }
    public List<Question> AllQuestions { get => allQuestions; private set => allQuestions = value; }
}
