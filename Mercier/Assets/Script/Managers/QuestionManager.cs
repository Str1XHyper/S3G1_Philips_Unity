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
        if(answer ==  allQuestions[0].answers[0].answer)
        {
            return true;
        }
        else
        {
            return false;
        }

        //Send Answer to Back-End
    }

    public void AskQuestion(Question question)
    {
        UI_manager.instance.ShowQuestionBox(question);
    }
    public List<Question> AllQuestions { get => allQuestions; private set => allQuestions = value; }
}
