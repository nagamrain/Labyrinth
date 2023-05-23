using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaitCountText : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public void UpdateWaitText(int value)
    {
        text.text = "Wait: " + value + "s";
    }
}
