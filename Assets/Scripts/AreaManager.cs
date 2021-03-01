using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AreaManager : MonoBehaviour
{
    bool isPutted = false;
    public int area;
    public ScoreScript scoreScript;
    public SceneScript sceneScript;
    public PuzzleSpowner puzzleSpowner;

    private void Start()
    {
        scoreScript = GameObject.Find("ScoreManager").GetComponent<ScoreScript>();
        sceneScript = GameObject.Find("SceneManager").GetComponent<SceneScript>();
        puzzleSpowner = GameObject.Find("PuzzleManager").GetComponent<PuzzleSpowner>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (other.gameObject.CompareTag("Hokkaido"))
            {
                Debug.Log("bbb");

                if (!isPutted)
                {
                    scoreScript.AddScore(area);
                    puzzleSpowner.puzzleSpown();
                    isPutted = true;
                }
            }

            if (other.gameObject.CompareTag("Border") || !other.gameObject.CompareTag("Hokkaido") )
            {
                Debug.Log("ccc");

                StartCoroutine(SceneChange());
            }
        }
    }

    // private void OnTriggerEnter(Collider other) {
    //     if(!other.gameObject.CompareTag("Hokkaido"))
    //     {
    //         Debug.Log("finish");
    //         StartCoroutine(SceneChange());
    //     }
    // }

    IEnumerator SceneChange()
    {
        Debug.Log("change");
        yield return new WaitForSeconds(2f);
        sceneScript.ChangeScene("ScoreScene");
    }
}
