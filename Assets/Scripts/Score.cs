using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEngine.Rendering.DebugUI;

public class Score : MoveDirection
{
    [SerializeField] SceneController controller;
    private Timer distance;
    [SerializeField] TextMeshProUGUI textScore;
    private float time;

    private void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (!controller.gameOver)
        {
            float speedMultiplier = 0;

            if (controller.powerUpPicker)
            {
                speedMultiplier = speed * speed;

                StartCoroutine(PowerUpStop());
            }

            else
                speedMultiplier = speed;


            time += Time.deltaTime * speedMultiplier;
            textScore.text = time.ToString("0");
        }

    }

    private IEnumerator PowerUpStop()
    {
        yield return new WaitForSeconds(5f);
        controller.TurnOffPowerUp();

    }






}
