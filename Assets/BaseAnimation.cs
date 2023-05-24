using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimation : ScriptableObject
{
    [SerializeField] protected float duration;
    public virtual void Animate(Transform visual)
    {

    }
}
