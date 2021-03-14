using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneScript : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    GameObject hokkaido;
    // AudioSource audio;
    public IEnumerator SceneChange(string name)
    {
        // if(name == "ScoreScene")
        // {
        //     audio = GetComponent<AudioSource>();
        //     audio.PlayOneShot(audio.clip);
        // }

        Debug.Log("change");
        hokkaido = Instantiate(gameObject ,gameObject.transform.position, Quaternion.identity);
        hokkaido.transform.localScale = new Vector3(0.01f,0.01f,0.01f);
        hokkaido.transform.DOScale(
            new Vector3(30f,30f,30f),
            2.0f
        ).SetEase(Ease.InQuint);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(name);
    }
}
