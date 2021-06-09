using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    //Leaderboard
    [Header("Leaderboard")]
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

    public void UpdateTopThree(List<ScoreResponse> scoreListSorted)
    {
        firstPointText.text = scoreListSorted[0].Points.ToString();
        firstStarText.text = scoreListSorted[0].Stars.ToString();
        firstNameText.text = scoreListSorted[0].Username.ToString();

        if (scoreListSorted.Count >= 2)
        {
            secondPointText.text = scoreListSorted[1].Points.ToString();
            secondStarText.text = scoreListSorted[1].Stars.ToString();
            secondNameText.text = scoreListSorted[1].Username.ToString();

            if (scoreListSorted.Count >= 3)
            {
                thirdPointText.text = scoreListSorted[2].Points.ToString();
                thirdStarText.text = scoreListSorted[2].Stars.ToString();
                thirdNameText.text = scoreListSorted[2].Username.ToString();
            }
        }
    }


    public static void SaveLeaderboard()
    {
        List<ScoreResponse> leaderBoardScores = UI_manager.instance.Leaderboard;
        if(!string.IsNullOrEmpty(leaderBoardScores[0].Username))
        {
            PlayerPrefs.SetString("Pos1Name", leaderBoardScores[0].Username);
            PlayerPrefs.SetInt("Pos1Points", leaderBoardScores[0].Points);
            PlayerPrefs.SetInt("Pos1Stars", leaderBoardScores[0].Stars);
        };

        if (leaderBoardScores.Count >= 2)
        {
            if (!string.IsNullOrEmpty(leaderBoardScores[1].Username))
            {
                PlayerPrefs.SetString("Pos2Name", leaderBoardScores[1].Username);
                PlayerPrefs.SetInt("Pos2Points", leaderBoardScores[1].Points);
                PlayerPrefs.SetInt("Pos2Stars", leaderBoardScores[1].Stars);
            }

            if(leaderBoardScores.Count >= 3)
            {
                if (!string.IsNullOrEmpty(leaderBoardScores[2].Username))
                {
                    PlayerPrefs.SetString("Pos3Name", leaderBoardScores[2].Username);
                    PlayerPrefs.SetInt("Pos3Points", leaderBoardScores[2].Points);
                    PlayerPrefs.SetInt("Pos3Stars", leaderBoardScores[2].Stars);
                }
            }
        }
    }
}
