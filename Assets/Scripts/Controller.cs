using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Controller : MonoBehaviour
{
    // RaycastHit hit; //レイキャストが当たったものを取得する入れ物
    RaycastHit2D hit;
    bool isMoving = false;
    Vector2 firstPos;
    Vector2 posDistance;
    Vector2 puzzlePos;
    Vector2 mousePos;
    float adjustX;
    float adjustY;
    GameObject selectedPuzzle;
    float rotateSpeed = 90f;

    private void Start()
    {
        adjustX = 60.0f / Screen.width;
        adjustY = 33.0f / Screen.height;

        //         Debug.Log(adjustX);
        // Debug.Log(adjustY);

    }
    void Update()
    {
        mousePos = new Vector2
            (
            Input.mousePosition.x * adjustX,
            Input.mousePosition.y * adjustY
            );
        // mousePos = Input.mousePosition;
        // Debug.Log("posX = "　+ Input.mousePosition.x * adjustX
        //             + "posy = " + Input.mousePosition.y * adjustY);

        if (Input.GetMouseButtonDown(0)) //マウスがクリックされたら
        {
            float distance = 100;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //マウスのポジションを取得してRayに代入
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, 5f, false);
            firstPos = mousePos; //クリックした場所を保存

            hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, distance);
            if (hit.collider)
            {
                // if (Physics.Raycast(ray, out hit, distance))  //マウスのポジションからRayを投げて何かに当たったらhitに入れる
                if (hit.collider.CompareTag("Puzzle"))
                {
                    selectedPuzzle = hit.collider.gameObject;
                    posDistance = firstPos - (Vector2)selectedPuzzle.transform.position;
                    isMoving = true;
                    // string objectName = hit.collider.gameObject.name; //オブジェクト名を取得して変数に入れる
                    // Debug.Log(objectName); //オブジェクト名をコンソールに表示
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }

        if (isMoving) Moving();
    }

    void Moving()
    {
        puzzlePos = mousePos - posDistance;
        // puzzlePos = Input.mousePosition;
        // Debug.Log(puzzlePos);
        selectedPuzzle.transform.position = puzzlePos;

        float dz = Input.GetAxis("Horizontal");
        selectedPuzzle.transform.Rotate(0, 0, dz * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(("aaa"));
        if (other.gameObject.CompareTag("Hokkaido"))
        {
            // safeMaterial.color =new Color (255,0,0,100);
        }
    }

}
