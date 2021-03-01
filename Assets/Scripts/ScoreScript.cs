using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreScript : MonoBehaviour
{
    int score = 0;
    int textnum;
    [SerializeField] Text text;
    void Update()
    {
        DOTween.To
            (
                () => textnum,       //何に
                (x) => textnum = x,  //何を
                score,     //どこまで(最終的な値)
                1f		//どれくらいの時間
            );
        text.text = (textnum.ToString() +"km³");
    }

    public void AddScore(int num)
    {
        score += num;
        Debug.Log(score);
    }
}
