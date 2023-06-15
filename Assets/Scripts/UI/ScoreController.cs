using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    #region SerializeField
    [SerializeField] TMP_Text text_score;
    [SerializeField] TMP_Text text_coin;
    [SerializeField] TMP_Text text_diamond;
    #endregion

    public void IncreaseScore(int score)
    {
        int curScore = int.Parse(text_score.text);
        text_score.text = (curScore + score).ToString();
    }

    public void IncreaseCoin(int coin)
    {
        int curScore = int.Parse(text_coin.text);
        text_coin.text = (curScore + coin).ToString();
    }

    public void IncreaseDiamond(int diamond)
    {
        int curScore = int.Parse(text_diamond.text);
        text_diamond.text = (curScore + diamond).ToString();
    }
}
