using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> obstaclesPrefab;
    private List<Vector3> spawnPos;
    private List<Transform> obstacles = new List<Transform>();


    private void Awake()
    {
        spawnPos = new List<Vector3>()
        {
            new Vector3(2.1f,-127.31f,270.22f),
            new Vector3(14.01f,-144f,306.1f),
            new Vector3(2.1f,-165.1f,351.3f),
            new Vector3(-10.5f,-164.9f,351.3f),
            new Vector3(14.01f,-181.8f,387.3f),
            new Vector3(14.01f,-127.31f,270.22f),
            new Vector3(2.1f,-165.1f,351.5f),
            new Vector3(2.1f,-143.6f,305.1f),
            new Vector3(-10.5f,-181.8f,387.3f),
            new Vector3(14.01f,-181.8f,387.3f),
        };

        foreach (Transform t in obstaclesPrefab)
        {
            var obj = Instantiate(t,transform);
            obj.gameObject.SetActive(false);
            obstacles.Add(obj);
        }

    }

    void Start()
    {

        InvokeRepeating("ActiveObstacle", 3, 2);

    }

    private void ActiveObstacle()
    {
        int randomPos = Random.Range(0, spawnPos.Count);
        foreach (Transform t in obstacles)
        {
            if (!t.gameObject.activeInHierarchy)
            {
                t.gameObject.SetActive(true);
                t.transform.position = spawnPos[randomPos];
                break;
            }
        }
    }

}
