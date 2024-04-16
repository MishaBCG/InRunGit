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
    [SerializeField] SceneController controller;


    private int lineToMove = 1;
    [SerializeField] private float lineDistance = 4;

    private bool canMove = true;
    private Vector3 targetPosition;
    void Start()
    {

    }

    private void Update()
    {
        if (!controller.gameOver)
        {
            if (SwipeController.swipeRight || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                if (lineToMove < 2 && canMove)
                {
                    lineToMove++;
                    targetPosition = (Vector3.right * lineDistance) + transform.position;

                    StartCoroutine(MoveRight());
                }

            if (SwipeController.swipeLeft || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                if (lineToMove > 0 && canMove)
                {
                    lineToMove--;
                    targetPosition = (Vector3.left * lineDistance) + transform.position;
                    StartCoroutine(MoveRight());
                }

        }

    }


    private IEnumerator MoveRight()
    {

        Vector3 startPoss = transform.position;
        float t = 0f;
        canMove = false;
        while (t < 1f)
        {
            t += Time.deltaTime / speed;
            yield return transform.position = Vector3.Lerp(startPoss, targetPosition, t);
        }
        canMove = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent(out PowerUpBehaviour powerUp);
        other.gameObject.TryGetComponent(out CoinBehaviour coin);
        if (powerUp != null)
        {
            controller.TurnOnPowerUp();
        }

        else if (coin != null)
        {
            controller.AddCoin();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.TryGetComponent(out ObstaclesMovement obj);
        if (obj != null)
        {
            controller.GameOver();
            StartCoroutine(Restart());
        }

    }

    private IEnumerator Restart()
    {
        //здесь анимация смерти
        yield return new WaitForSeconds(2);

        controller.RestartPanel();
    }
        




    

}
