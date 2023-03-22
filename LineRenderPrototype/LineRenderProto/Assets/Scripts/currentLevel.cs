using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class currentLevel : MonoBehaviour
{
    public Vector2 EndPosition;
    public float moveTime;
    private TextMeshProUGUI levelText;

    // Start is called before the first frame update
    void Start()
    {
        levelText = GetComponent<TextMeshProUGUI>();
        LevelUIMove();
    }

    void LevelUIMove()
    {
        levelText.text = GameManager.Instance.getSceneName();
        Sequence seq = DOTween.Sequence();
        seq.Append(GetComponent<RectTransform>().DOLocalMove(EndPosition, moveTime).SetEase(Ease.Linear));
        seq.AppendInterval(1.0f);
        seq.Append(levelText.DOFade(0, moveTime / 1.2f));
    }
}
