using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI coins;


    private void Awake()
    {
     
    }


    private void Start()
    {
        ForSaveInfo.instance.LoadGame();
        GetParametrs();     
    }


    private void OnEnable()
    {
        SceneController.gameIsOver += GetParametrs;
    }
    private void OnDisable()
    {
        SceneController.gameIsOver -= GetParametrs;
    }



    private void GetParametrs()
    {
        score.text = ForSaveInfo.instance.bestPlayer + " " + ForSaveInfo.instance.bestScore;
        coins.text = ForSaveInfo.instance.coins.ToString();

    }






    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else 
        Application.Quit();
        
#endif

    }


    public void PullPlayerName(string name)
    {
        ForSaveInfo.instance.namePlayer = name;
    }







}
