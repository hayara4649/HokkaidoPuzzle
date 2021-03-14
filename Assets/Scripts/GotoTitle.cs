using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoTitle : MonoBehaviour
{
    SceneScript sceneScript;

    private void Start() 
    {
        sceneScript = GameObject.Find("SceneManager").GetComponent<SceneScript>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            sceneScript.StartCoroutine(sceneScript.SceneChange("Title"));
            ScoreScript.score=0;
        }
    }
}
