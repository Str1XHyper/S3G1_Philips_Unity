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
        //LoadAllQuestionsFromLesson(GetLessonIdFromURL());
        LoadAllQuestionsFromLesson("");
    }

    private string GetLessonIdFromURL()
    {
        string url = Application.absoluteURL;

        string lessonIDFromUrl = url.Split('=')[1];

        return lessonIDFromUrl;
    }

    public void LoadAllQuestionsFromLesson(string LessonId)
    {
        LessonId = "1";

        string uri = "localhost:3000/Question/Planned/" + LessonId;

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

            Debug.Log(questions[0].question);
            Debug.Log(response);
            UI_manager.instance.UpdateText();
        }
    }
}
