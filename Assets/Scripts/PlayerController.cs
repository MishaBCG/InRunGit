using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    private float speed = 0.1f;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;


    private int lineToMove = 1;
    [SerializeField] private float lineDistance = 4;

    private bool canMove = true;
    private Vector3 targetPosition;
    void Start()
    {
       
    }

    private void Update()
    {
        if (SwipeController.swipeRight || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            if (lineToMove < 2 && canMove)
            {
                lineToMove++;
                targetPosition = (Vector3.right * lineDistance) + transform.position;
                
                StartCoroutine(MoveRight());
            }

        if (SwipeController.swipeLeft || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            if(lineToMove > 0 && canMove)
            {
                lineToMove--;
                targetPosition = (Vector3.left * lineDistance) + transform.position;
                StartCoroutine(MoveRight());
            }
                
    }


    private IEnumerator MoveRight()
    {
        
        Vector3 startPoss = transform.position;
        float t = 0f;
        canMove = false;
        while(t < 1f)
        {
            t += Time.deltaTime / speed;
            yield return transform.position = Vector3.Lerp(startPoss, targetPosition, t);
        }
        canMove = true;
    }












    //private void Jump()
    //{
    //    direction.y = jumpForce;
    //}




    // Update is called once per frame
    //void FixedUpdate()
    //{
         //direction.y += gravity * Time.fixedDeltaTime;
        //characterController.Move(direction *Time.deltaTime);
    //}
}
