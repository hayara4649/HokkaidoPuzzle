using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public static int score = 0;
    int textnum = 0;
    [SerializeField] Text text;
    [SerializeField] Text time;
    [SerializeField] float[] phase;
    float remainingTime;
    bool timeOver = false;
    SceneScript sceneScript;
    Sounds sounds;
    GameObject canvas;
    int puzzlenum;
    GameObject gameover;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "ScoreScene")
        {
            DisplayScore();
        }
        phase = new float[] { 20f, 15f, 10f };
        remainingTime = phase[0];
        puzzlenum = 0;

        sceneScript = GameObject.Find("SceneManager").GetComponent<SceneScript>();

        sounds = GameObject.Find("SoundManager").GetComponent<Sounds>();
        canvas = GameObject.Find("Canvas");

        gameover = canvas.transform.Find("Gameover").gameObject;
    }
    void FixedUpdate()
    {
        // if (textnum < score) textnum++;
        DOTween.To
            (
                () => textnum,       //何に
                (x) => textnum = x,  //何を
                score,     //どこまで(最終的な値)
                0.5f		//どれくらいの時間
            );
        // Debug.Log((score));
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0f)
        {
            remainingTime = 0;
            if (!timeOver)
            {
                sceneScript.StartCoroutine(sceneScript.SceneChange("ScoreScene"));
                sounds.TimeOver();
                timeOver = true;
                gameover.SetActive(true);
                gameover.GetComponent<Text>().text = "TimeOver!";
            }
        }
        text.text = (textnum.ToString() + "km³");
        if (time) 
        {
            if(remainingTime<=5f)
            {
            time.text = "残り<color=#FF0000>" + remainingTime.ToString("f2") + "</color>秒";
            }
            else
            {
            time.text = "残り" + remainingTime.ToString("f2") + "秒";    
            }
        }
    }

    void DisplayScore()
    {
        Debug.Log(Time.timeScale);
        textnum = score;
        text.text = (textnum.ToString() + "km³");
    }

    public void AddScore(int num)
    {
        score += num;
        // Debug.Log(textnum);
    }


    public void ResetTime()
    {
        puzzlenum++;
        // Debug.Log(puzzlenum);

        if (puzzlenum < 5)
        {
            remainingTime = phase[0];
        }
        else if (puzzlenum >= 5 && puzzlenum < 10)
        {
            remainingTime = phase[1];
        }
        else
        {
            remainingTime = phase[2];
        }
    }

    public void GameOver(string text)
    {
        // gameover = canvas.transform.Find("Gameover").gameObject;
        gameover.SetActive(true);
        sounds.Out();
        gameover.GetComponent<Text>().text = "OUT!";
    }


}
