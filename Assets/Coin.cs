using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] Transform visual;
    [SerializeField] CoinData coinData;
    [SerializeField, Range(0,10)] float rotationSpeed = 1;

    public int Value { get => coinData.value; }

    private void Start() {
        visual.GetComponent<Renderer>().material = coinData.material;
    }

    void Update()
    {
        transform.Rotate(0, 360 * rotationSpeed * Time.deltaTime, 0);
    }

    public void Collected()
    {
        GetComponent<Collider>().enabled = false;
        this.transform.DOScale(
            2f,
            0.4f
        ).onComplete = SelfDestruct;

    }

    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
}
