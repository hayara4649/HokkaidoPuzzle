using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ButtonScript : UIBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float Rate;
    [SerializeField] PuzzleSpowner puzzleSpowner;
    private Vector3 BaseScale;  //元のScaleを取得
    SceneScript sceneScript;

    protected override void Start()
    {
        base.Start();
        BaseScale = transform.localScale;
        // puzzleSpowner = GameObject.Find("PuzzleManager").GetComponent<PuzzleSpowner>();

        sceneScript = GameObject.Find("SceneManager").GetComponent<SceneScript>();
    }

    //マウスが乗っかったら大きく
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(BaseScale * Rate, 0.25f)
        .SetEase(Ease.OutBounce);
    }

    //マウスが離れたら素の大きさに
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(BaseScale, 0.25f)
        .SetEase(Ease.OutBounce);
    }

    public void OnClicked()
    {
        puzzleSpowner.puzzleReset();
    }

    public void Retry()
    {
        sceneScript.StartCoroutine(sceneScript.SceneChange("Title"));
        ScoreScript.score = 0;
    }
}
