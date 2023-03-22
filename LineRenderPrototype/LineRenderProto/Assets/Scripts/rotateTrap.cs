using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class rotateTrap : MonoBehaviour
{
    public Vector3 rotationVector;
    public float rotationTime;

    // Start is called before the first frame update
    void Start()
    {
        rotation();
    }

    void rotation()
    {
        transform.DORotate(rotationVector, rotationTime).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }

}
