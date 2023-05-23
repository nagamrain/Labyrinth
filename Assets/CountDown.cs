using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class CountDown : MonoBehaviour
{
    [SerializeField] int duration;
    public UnityEvent OnCountFinished = new UnityEvent();
    public UnityEvent<int> OnCount = new UnityEvent<int>();
    bool isCounting;

    public void StartCount()
    {
        if (isCounting == true)
            return;
        else
            isCounting = true;

        var seq = DOTween.Sequence();

        OnCount.Invoke(duration);

        for (int i = duration - 1; i >= 0; i--)
        {
            seq.Append(transform
                .DOMove(this.transform.position, 1)
                .OnComplete(() => OnCount.Invoke(i)));
        }
        seq.Append(transform
        .DOMove(this.transform.position, 1));
        OnCountFinished.Invoke();
    }
}
