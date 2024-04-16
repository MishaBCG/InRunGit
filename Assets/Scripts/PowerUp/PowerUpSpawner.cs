using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] SceneController controller;
    [SerializeField] PowerUpBehaviour powerUp;
    private List<PowerUpBehaviour> powerUpToSpawn = new List<PowerUpBehaviour>();
    private List<Vector3> listSpawnPos;
    void Start()
    {
        listSpawnPos = new List<Vector3>()
        {
            new Vector3(0,-257.57f,553.66f),
            new Vector3(-5f,-257.57f, 553.66f),
            new Vector3(5f,-257.57f, 553.66f),

        };
        var obj = Instantiate(powerUp);
        obj.gameObject.SetActive(false);
        powerUpToSpawn.Add(obj);


        InvokeRepeating("PowerUpSpawn",0,33);


    }

    // Update is called once per frame
    private void PowerUpSpawn()
    {
        if(!controller.gameOver)
        {
            int randomPos = Random.Range(0, listSpawnPos.Count);

            foreach (var obj in powerUpToSpawn)
            {
                if (!obj.gameObject.activeInHierarchy)
                {
                    obj.gameObject.SetActive(true);
                    obj.transform.position = listSpawnPos[randomPos];
                }
            }
        }

    }










}
