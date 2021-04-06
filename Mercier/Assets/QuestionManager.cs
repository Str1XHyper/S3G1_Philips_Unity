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

    private int currentQuestionIndex = 0;

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

    public void AskQuestion()
    {
        //TODO: Hier vraag op scherm laten zien TIJN

        Debug.Log(allQuestions[currentQuestionIndex].question);

        currentQuestionIndex++;
    }
    public List<Question> AllQuestions { get => allQuestions; private set => allQuestions = value; }
}
