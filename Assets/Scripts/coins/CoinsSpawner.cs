using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] SceneController controller;
    [SerializeField] CoinsPool pool;
    private List<Vector3> spawnPos;
    void Awake()
    {
        spawnPos = new List<Vector3>()
        {
            new Vector3(-7.88f,-228.7f,491.8f),
            new Vector3(0,-228.7f,491.8f),
            new Vector3(10.32f,-228.7f,491.8f),



        }
        ;
    }


    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("GetCoins",5,15);
    }


    private void GetCoins()
    {

            StartCoroutine(WaitSec());
        
    }

    private IEnumerator WaitSec()
    {
        if(!controller.gameOver)
        {
            float maxCoins = Random.RandomRange(3f, 10f);
            var randomPos = Random.Range(0, spawnPos.Count);
            for (int i = 0; i < maxCoins; i++)
            {
                var coin = pool.TakeCoin();
                coin.transform.position = spawnPos[randomPos];
                yield return new WaitForSeconds(0.2f);
            }
        }

    }


}
