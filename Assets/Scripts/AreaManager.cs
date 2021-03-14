using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AreaManager : MonoBehaviour
{
    public bool isPutted = false;
    public int area;
    ScoreScript scoreScript;
    SceneScript sceneScript;
    PuzzleSpowner puzzleSpowner;
    SpriteRenderer renderer;
    // Rigidbody2D rigidbody;
    Sounds sounds;
    GameObject canvas;

    Color danger;
    Color safe;

    private void Start()
    {
        scoreScript = GameObject.Find("ScoreManager").GetComponent<ScoreScript>();
        sceneScript = GameObject.Find("SceneManager").GetComponent<SceneScript>();
        puzzleSpowner = GameObject.Find("PuzzleManager").GetComponent<PuzzleSpowner>();

        sounds = GameObject.Find("SoundManager").GetComponent<Sounds>();
        canvas = GameObject.Find("Canvas");

        renderer = GetComponent<SpriteRenderer>();

        danger = new Color(255,0,0);
        safe = new Color(184, 222, 111);
    }

    // private void OnTriggerEnter2D(Collider2D other) 
    // {
    //     Debug.Log("enter");
    //     // if(rigidbody.IsSleeping())   rigidbody.WakeUp();   
    // }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Border") || other.gameObject.CompareTag("Puzzle"))
        {
            renderer.color = danger;

            //クリックを離したときに
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("out");
                scoreScript.GameOver("OUT!");
                sceneScript.StartCoroutine(sceneScript.SceneChange("ScoreScene"));
                isPutted = true;
            }
        } 
        else 
        {
            renderer.color = safe;
            //クリックを離したときに
            if (Input.GetMouseButtonUp(0) && !isPutted)
            {
                sounds.Put();
                    scoreScript.AddScore(area);
                    puzzleSpowner.puzzleSpown();
                    isPutted = true;
                    scoreScript.ResetTime();
            }
        }
        
        // if (other.gameObject.CompareTag("Border") || other.gameObject.CompareTag("Puzzle"))
        // {
        //     renderer.color = danger;
        // } 
        // else 
        // {
        //     renderer.color = safe;
        // }
        // //クリックを離したときに
        // if (Input.GetMouseButtonUp(0))
        // {
        //     //パズルがはみ出していたらリザルト画面 
        //     if (other.gameObject.CompareTag("Border") || other.gameObject.CompareTag("Puzzle"))
        //     {
        //         Debug.Log("out");
        //         scoreScript.GameOver("OUT!");
        //         sceneScript.StartCoroutine(sceneScript.SceneChange("ScoreScene"));
        //         isPutted = true;
        //     }
        //     //パズルが北海道の内部だったらスコア加算
        //     else if (other.gameObject.CompareTag("Hokkaido"))
        //     {
        //         Debug.Log("hokkaido");
        //         if (!isPutted)
        //         {
        //             sounds.Put();
        //             scoreScript.AddScore(area);
        //             puzzleSpowner.puzzleSpown();
        //             isPutted = true;
        //             scoreScript.ResetTime();
        //         }
        //     }
            
        // }
    }

    // private void OnTriggerExit2D(Collision2D other) 
    // {
    //     Debug.Log("exit");
    //     if(rigidbody.IsAwake()) rigidbody.Sleep();
    // }



}
