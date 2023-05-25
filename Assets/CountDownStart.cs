using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
public class CountDownStart : MonoBehaviour
{
    [SerializeField] int duration;
    public UnityEvent OnCountFinished = new UnityEvent();
    public UnityEvent<int> OnCount = new UnityEvent<int>();
    bool isCounting;
    Sequence seq;

    private void Start() 
    {
        if (isCounting == true)
            return;
        else
            isCounting = true;

        seq = DOTween.Sequence();

        OnCount.Invoke(duration);

        for (int i = duration - 1; i >= 0; i--)
        {
            var count = i;
            seq.Append(transform
                .DOMove(this.transform.position, 1)
                .SetUpdate(true)
                .OnComplete(() => OnCount.Invoke(count)));
        }
        seq.Append(transform
            .DOMove(this.transform.position, 1))
            .SetUpdate(true)
            .OnComplete(() => {
                isCounting = false;
                OnCountFinished.Invoke();
                }
            );
    }
}
