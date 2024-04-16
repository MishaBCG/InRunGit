using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coins;
    [SerializeField] GameObject restartPanel;
    [SerializeField] GameObject pausePanel;
    private float numberOfCoins = 0;
    public bool gameOver { get; private set; }
    public bool powerUpPicker { get; private set; } = false;


    private void Awake()
    {
       Time.timeScale = 1.0f;
    }

    void Start()
    {
        gameOver = false;
        coins.text = $"Монет: {numberOfCoins}";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }


    }

    public void TurnOnPowerUp()
    {
        powerUpPicker=true;
        Debug.Log("PowerUpWasPiCKED");
    }
    public void TurnOffPowerUp()
    {
        powerUpPicker = false;
        Debug.Log("StopPowerUp");
    }

    public void GameOver()
    {
       // Time.timeScale = 0;
        gameOver = true;
       
    }

    public void AddCoin()
    {
        numberOfCoins++;
        coins.text = $"Монет: {numberOfCoins}";
    }

    public void RestartPanel()
    {
        restartPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void Resume()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);

        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }



}
