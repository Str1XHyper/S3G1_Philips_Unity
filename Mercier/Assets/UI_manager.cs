using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public void UpdateText()
    {
        pointText.text = TurnManager.instance.CurrentPlayerGroup.CurrentMoneyAmount.ToString();
        starText.text = TurnManager.instance.CurrentPlayerGroup.CurrentAmountOfStars.ToString();
    }

    public void UpdateQuestion(string questionText)
    {
        this.questionText.text = questionText;
    }

    public TMP_Text PointText { get => pointText; private set => pointText = value; }
    public TMP_Text StarText { get => starText; private set => starText = value; }
    public TMP_Text QuestionText { get => questionText; private set => questionText = value; }
}
