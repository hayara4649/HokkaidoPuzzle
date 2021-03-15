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

    [SerializeField] bool isChangeable = false;
    [SerializeField] bool isUnchangeable = false;

    private void Start()
    {
        scoreScript = GameObject.Find("ScoreManager").GetComponent<ScoreScript>();
        sceneScript = GameObject.Find("SceneManager").GetComponent<SceneScript>();
        puzzleSpowner = GameObject.Find("PuzzleManager").GetComponent<PuzzleSpowner>();

        sounds = GameObject.Find("SoundManager").GetComponent<Sounds>();
        canvas = GameObject.Find("Canvas");

        renderer = GetComponent<SpriteRenderer>();

        danger = new Color(255, 0, 0);
        safe = new Color(184, 222, 111);
    }

    private void Update()
    {
        if (isUnchangeable)
        {
            renderer.color = danger;
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("out");
                scoreScript.GameOver("OUT!");
                sceneScript.StartCoroutine(sceneScript.SceneChange("ScoreScene"));
                isPutted = true;
            }

        }
        if (isChangeable && !isUnchangeable)
        {
            renderer.color = safe;
            if (Input.GetMouseButtonUp(0) && !isPutted)
            {
                sounds.Put();
                scoreScript.AddScore(area);
                puzzleSpowner.puzzleSpown();
                isPutted = true;
                scoreScript.ResetTime();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Border") || other.gameObject.CompareTag("Puzzle"))
        {
            isUnchangeable = true;
        }
        else if (other.gameObject.CompareTag("Hokkaido"))
        {
            isChangeable = true;
        }
    }
    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Border") || other.gameObject.CompareTag("Puzzle"))
    //     {
    //         renderer.color = danger;

    //         //クリックを離したときに
    //         if (Input.GetMouseButtonUp(0))
    //         {
    //             Debug.Log("out");
    //             scoreScript.GameOver("OUT!");
    //             sceneScript.StartCoroutine(sceneScript.SceneChange("ScoreScene"));
    //             isPutted = true;
    //         }
    //     } 
    //     else 
    //     {
    //         renderer.color = safe;
    //         //クリックを離したときに
    //         if (Input.GetMouseButtonUp(0) && !isPutted)
    //         {
    //             sounds.Put();
    //                 scoreScript.AddScore(area);
    //                 puzzleSpowner.puzzleSpown();
    //                 isPutted = true;
    //                 scoreScript.ResetTime();
    //         }
    //     }
    // }

    // private void OnTriggerExit2D(Collision2D other) 
    // {
    //     Debug.Log("exit");
    //     if(rigidbody.IsAwake()) rigidbody.Sleep();
    // }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Border") || other.gameObject.CompareTag("Puzzle"))
        {
            isUnchangeable = false;
        }
        else if (other.gameObject.CompareTag("Hokkaido"))
        {
            isChangeable = false;
        }
    }



}
