using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GroundMove : MoveDirection
{
    // Start is called before the first frame update
    private BoxCollider boxCollider;
    private Vector3 startPos;
    private float endPoint = -75f;



    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        startPos = new Vector3(1.75f, -280.749f, 602f);
    }

    void Update()
    {
        PosCheck();
        Move();

    }

    private void PosCheck()
    {
        if (boxCollider.transform.position.z < endPoint)
            transform.position = startPos;
    }

}
