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
    [Space]
    [SerializeField] private TMP_Text secondPointText;
    [SerializeField] private TMP_Text secondStarText;
    [Space]
    [SerializeField] private TMP_Text thirdPointText;
    [SerializeField] private TMP_Text thirdStarText;

    public void UpdateTopThree(List<ScoreResponse> scoreListSorted)
    {
        firstPointText.text = scoreListSorted[0].Points.ToString();
        firstStarText.text = scoreListSorted[0].Stars.ToString();

        if(scoreListSorted.Count >= 2)
        {
            secondPointText.text = scoreListSorted[1].Points.ToString();
            secondStarText.text = scoreListSorted[1].Stars.ToString();

            if(scoreListSorted.Count >= 3)
            {
                thirdPointText.text = scoreListSorted[2].Points.ToString();
                thirdStarText.text = scoreListSorted[2].Stars.ToString();
            }
        }
    }
}
