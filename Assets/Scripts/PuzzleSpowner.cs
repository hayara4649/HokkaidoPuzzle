using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleSpowner : MonoBehaviour
{
    public GameObject[] puzzle;
    public GameObject spowner; 
    [SerializeField] GameObject currentPuzzle;
    [SerializeField] Text puzzlename;
    Vector3 spownerPos;

    void Start()
    {
        spownerPos = spowner.transform.position;
        int a = Random.Range(0,47);
        currentPuzzle = Instantiate(puzzle[a], spownerPos,Quaternion.identity);
        puzzlename.text = puzzle[a].gameObject.name;
        
    }


    public void puzzleSpown()
    {
        int a = Random.Range(0,47);
        currentPuzzle = Instantiate(puzzle[a], spownerPos,Quaternion.identity); 
        puzzlename.text = puzzle[a].gameObject.name;   
    }

    public void puzzleReset()
    {
        Destroy(currentPuzzle);
        int a = Random.Range(0,47);
        currentPuzzle = Instantiate(puzzle[a], spownerPos,Quaternion.identity);   
        puzzlename.text = puzzle[a].gameObject.name; 
    
    }
}
