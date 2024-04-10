using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Score : MonoBehaviour
{

    private Timer distance;
    [SerializeField] TextMeshProUGUI textScore;
    private float time;

    private void Start()
    {
     
    }


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        textScore.text = time.ToString("0");

    }
}
