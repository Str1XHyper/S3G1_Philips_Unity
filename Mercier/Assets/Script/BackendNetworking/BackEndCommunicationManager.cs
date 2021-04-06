using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BackEndCommunicationManager : MonoBehaviour
{
    #region SingleTon

    public static BackEndCommunicationManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    public Question[] questions;

    private void Start()
    {
        LoadAllQuestionsFromLesson("");

        //TODO: Call this from where it is supposed to be called
    }

    public void LoadAllQuestionsFromLesson(string LessonId)
    {
        LessonId = "ac04dcab-b025-45ff-b90a-d15b73759284";

        string uri = "localhost:3000/Question/" + LessonId;

        StartCoroutine(GetAllQuestions(uri));
    }

    IEnumerator GetAllQuestions(string uri)
    {
        UnityWebRequest www = UnityWebRequest.Get(uri);
        yield return www.SendWebRequest();

        if (www.responseCode == 200)
        {
            string response = www.downloadHandler.text;
            questions = JsonHelper.getJsonArray<Question>(response);
        }
    }
}
