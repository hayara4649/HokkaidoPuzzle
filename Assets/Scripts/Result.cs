
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Result : MonoBehaviour
{
    [SerializeField] GameObject[] result;
    public Text[] resultText;
    int array;
    int hokkaido = 83424;
    [SerializeField] AudioClip[] clips;
    AudioSource source;
    int textnum = 0;

    void Start()
    {
        array = 0;
        source = GetComponent<AudioSource>();
        resultText = new Text[result.Length];
        for (int i = 0; i < result.Length; i++)
        {
            resultText[i] = result[i].GetComponent<Text>();
        }
        StartCoroutine(ShowResult());
    }

    private void Update() {
        resultText[1].text = textnum.ToString("") + "km³";
    }


    IEnumerator ShowResult()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < result.Length; i++)
        {
            result[array].SetActive(true);
            source.clip = clips[i];
            switch (array)
            {
                case 0:
                    source.PlayOneShot(source.clip);
                    break;

                case 1:
                    source.PlayOneShot(source.clip);
                    yield return new WaitForSeconds(0.4f);
                    DOTween.To
            (
                () => textnum,       //何に
                (x) => textnum = x,  //何を
                ScoreScript.score,     //どこまで(最終的な値)
                2.5f		//どれくらいの時間
            );
                    // resultText[i].text = textnum.ToString("") + "km³";

                    yield return new WaitForSeconds(3f);
                    break;
                case 2:
                    resultText[i].text = "北海道" + ((float)ScoreScript.score / (float)hokkaido).ToString("f2") + "個分";
                    source.PlayOneShot(source.clip);
                    break;
            }


            array++;
            yield return new WaitForSeconds(1f);
        }
    }

}

