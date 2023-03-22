using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class collectible : MonoBehaviour
{
    private void Start()
    {
        transform.DORotate(new Vector3(0, 0, 360), 5f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        transform.DOPunchScale(new Vector3(0.15f, 0.15f, 0), 1f, 1, 0.1f).SetLoops(-1, LoopType.Restart);
    }


    
}
