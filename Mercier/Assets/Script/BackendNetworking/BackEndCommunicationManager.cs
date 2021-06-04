using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BackEndCommunicationManager : MonoBehaviour
{
    //[System.Runtime.InteropServices.DllImport("__Internal")]
    //private static extern string getQuestions();

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
        LoadAllQuestionsFromLesson(GetLessonIdFromURL());
        //LoadAllQuestionsFromLesson("");
        //SetAllQuestions(getQuestions());
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

        string uri = "http://localhost:3000/Question/Planned/" + LessonId;

        StartCoroutine(GetAllQuestions(uri));
    }

    public void SetAllQuestions(string json)
    {
        JsonToQuestionArray(json);
    }

    private void JsonToQuestionArray(string json)
    {
        questions = JsonHelper.getJsonArray<Question>(json);
    }

    IEnumerator GetAllQuestions(string uri)
    {
        UnityWebRequest www = UnityWebRequest.Get(uri);
        yield return www.SendWebRequest();

        if (www.responseCode == 200)
        {
            string response = www.downloadHandler.text;

            JsonToQuestionArray(response);

            Debug.Log(questions[0].question);
            Debug.Log(response);
            UI_manager.instance.UpdateText();
        }
    }
}
