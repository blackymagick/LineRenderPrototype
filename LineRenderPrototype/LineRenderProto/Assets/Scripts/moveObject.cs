using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class moveObject : MonoBehaviour
{
    public Vector2 startPosition;
    public Vector2 endPosition;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        moveFrom();
    }

    public void moveTo()
    {
        transform.DOLocalMove(startPosition, duration).SetEase(Ease.Linear);
    }

    public void moveFrom()
    {
        transform.DOLocalMove(endPosition, duration).SetEase(Ease.Linear);
    }

}
