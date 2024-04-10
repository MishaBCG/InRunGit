using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);

        transform.position = newPos;

    }
}
