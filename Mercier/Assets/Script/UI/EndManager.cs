using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    [SerializeField] private TMP_Text winnerText;
    [Space]
    [SerializeField] private TMP_Text firstPointText;
    [SerializeField] private TMP_Text firstStarText;
    [SerializeField] private TMP_Text firstNameText;
    [Space]
    [SerializeField] private TMP_Text secondPointText;
    [SerializeField] private TMP_Text secondStarText;
    [SerializeField] private TMP_Text secondNameText;
    [Space]
    [SerializeField] private TMP_Text thirdPointText;
    [SerializeField] private TMP_Text thirdStarText;
    [SerializeField] private TMP_Text thirdNameText;

    // Start is called before the first frame update
    void Start()
    {
        SetLeaderBoard();
    }

    private void SetLeaderBoard()
    {
        if (PlayerPrefs.HasKey("Pos1Name"))
        {
            firstNameText.text = PlayerPrefs.GetString("Pos1Name");
            firstPointText.text = PlayerPrefs.GetInt("Pos1Points").ToString();
            firstStarText.text = PlayerPrefs.GetInt("Pos1Stars").ToString();

            winnerText.text = "Winner is: " + PlayerPrefs.GetString("Pos1Name");
        }
        if(PlayerPrefs.HasKey("Pos2Name"))
        {
            secondNameText.text = PlayerPrefs.GetString("Pos2Name");
            secondPointText.text = PlayerPrefs.GetInt("Pos2Points").ToString();
            secondStarText.text = PlayerPrefs.GetInt("Pos3Points").ToString();
        };
        if(PlayerPrefs.HasKey("Pos3Name"))
        {
            thirdNameText.text = PlayerPrefs.GetString("Pos3Name");
            thirdPointText.text = PlayerPrefs.GetInt("Pos3Points").ToString();
            thirdStarText.text = PlayerPrefs.GetInt("Pos3Stars").ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
