using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RotateObject : MonoBehaviour
{
    public float rotationTime;
    public float rotationSpeed;
    public float randomTime;
    // Start is called before the first frame update
    void Start()
    {
        randomTime = Random.Range(1, 10);
        rotatingObject();
    }

    public void rotatingObject()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DORotate(Vector3.forward * rotationSpeed, rotationTime).SetEase(Ease.Linear).OnComplete(() =>
        {
            randomTime = Random.Range(1, 10);
        }));
        seq.AppendInterval(randomTime);
        seq.SetLoops(-1,LoopType.Yoyo);
    }

}
