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
    [SerializeField] TextMeshProUGUI textScore;
    private float distance;
    private string playerName;
    private float speedMultiplier;
    private int scoreForSave;
    private void Awake()
    {

    }


    private void Start()
    {
        if (ForSaveInfo.instance.namePlayer != "")
            playerName = ForSaveInfo.instance.namePlayer;
        else
            playerName = "";

    }


    // Update is called once per frame
    void Update()
    {
        if (!controller.gameOver)
        {
            // not optimal
            if (distance > 0)
               scoreForSave = (int)Mathf.Ceil(distance);

            if (controller.powerUpPicker)
            {
                speedMultiplier = speed * speed;

                StartCoroutine(PowerUpStop());
            }

            else
                speedMultiplier = speed;


            distance += Time.deltaTime * speedMultiplier;
            textScore.text =  $"{playerName}: " + distance.ToString("0");
        }

    }

    private IEnumerator PowerUpStop()
    {
        yield return new WaitForSeconds(5f);
        controller.TurnOffPowerUp();

    }

    private void OnEnable()
    {
        SceneController.gameIsOver += SaveBestScore;
    }

    private void OnDisable()
    {
        SceneController.gameIsOver -= SaveBestScore;
    }

    private void SaveBestScore()
    {
        if (ForSaveInfo.instance.ScoreToSave < scoreForSave)
        {
            ForSaveInfo.instance.ScoreToSave = scoreForSave;
            Debug.Log("Best Score Save");
        }
    }




}
