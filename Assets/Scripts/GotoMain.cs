using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoMain : MonoBehaviour
{
    public bool isPutted = false;
    PuzzleSpowner puzzleSpowner;
    SpriteRenderer renderer;
    // Rigidbody2D rigidbody;
    Sounds sounds;

    Color danger;
    Color safe;

    SceneScript sceneScript;

    private void Start()
    {
        sceneScript = GameObject.Find("SceneManager").GetComponent<SceneScript>();
        // puzzleSpowner = GameObject.Find("PuzzleManager").GetComponent<PuzzleSpowner>();

        sounds = GameObject.Find("SoundManager").GetComponent<Sounds>();

        renderer = GetComponent<SpriteRenderer>();

        danger = new Color(255, 0, 0);
        safe = new Color(184, 222, 111);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Border") || other.gameObject.CompareTag("Puzzle"))
        {
            renderer.color = danger;
        }
        else
        {
            renderer.color = safe;
        }
        //クリックを離したときに
        if (Input.GetMouseButtonUp(0))
        {


            //パズルが北海道の内部だったらスコア加算
            if (other.gameObject.CompareTag("Hokkaido"))
            {
                Debug.Log("hokkaido");
                if (!isPutted)
                {
                    sounds.Put();
                    sceneScript.StartCoroutine(sceneScript.SceneChange("Main-2D-"));
                    isPutted = true;
                }
            }

        }
    }
}
