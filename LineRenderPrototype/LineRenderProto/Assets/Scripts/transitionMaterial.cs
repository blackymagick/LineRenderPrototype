using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class transitionMaterial : MonoBehaviour
{
    public Material material;
    public float duration;

    void Start()
    {
        material.DOFloat(0, "_Cutoff", duration).From(1);
    }

    public void LevelEnd()
    {
        material.DOFloat(1, "_Cutoff", duration).SetEase(Ease.Linear);
    }

}
