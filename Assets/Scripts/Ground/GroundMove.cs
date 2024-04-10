using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 5;
    private Vector3 yTranslate;
    private Vector3 zTranslate;
    private BoxCollider boxCollider;
    private Vector3 startPos;
    private float endPoint = -75f;



    private void Awake()
    {
       boxCollider = GetComponent<BoxCollider>();
        startPos = new Vector3(1.75f, -280.749f, 602f);
    }

    void Start()
    {
        yTranslate = new Vector3(0, 0.001f, 0);
        zTranslate = new Vector3(0, 0, -1f);
    }

    // Update is called once per frame
    void Update()
    {
        PosCheck();
        Movement();
    }

    private void PosCheck()
    {
        if (boxCollider.transform.position.z < endPoint)
            transform.position = startPos;
    }

    private void Movement()
    {
        if (speed < 100)
            speed += speed * Time.deltaTime * 0.1f;
        transform.Translate(yTranslate * Time.deltaTime);
        transform.Translate(zTranslate * Time.deltaTime * speed);
    }
}
