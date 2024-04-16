using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPool : MonoBehaviour
{
    [SerializeField] private CoinBehaviour coinsPrefab;

    [SerializeField] private int numberOfCoins = 20;

    private ObjectsPool<CoinBehaviour> coins;


    void Start()
    {
        coins = new ObjectsPool<CoinBehaviour>(coinsPrefab,numberOfCoins, this.transform);
        coins.autoExpand = true;


      
    }

    public CoinBehaviour TakeCoin()
    {
        return coins.GetFreeElement();
    }
}
