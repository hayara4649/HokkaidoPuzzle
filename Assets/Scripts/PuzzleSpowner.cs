using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSpowner : MonoBehaviour
{
    public GameObject[] puzzle;
    public GameObject spowner; 
    Vector3 spownerPos;

    void Start()
    {
        spownerPos = spowner.transform.position;
        int a = Random.Range(0,47);
        Instantiate(puzzle[a], spownerPos,Quaternion.identity);
    }


    public void puzzleSpown()
    {
        int a = Random.Range(0,47);
        Instantiate(puzzle[a], spownerPos,Quaternion.identity);    
    }
}
