using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public UnityEvent<int> OnGetCoin;
     private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Coin"))
        {
            var coin = other.GetComponent<Coin>();    
            OnGetCoin.Invoke(coin.Value);
            coin.Collected();      
        }
    }
}
