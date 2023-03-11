using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class endGoal : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(2, 2, 2);
    public float duration = 0.5f;

    private void Start()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(targetScale, duration).SetEase(Ease.Linear);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.Instance.GoalAction?.Invoke();
        }
    }
}
