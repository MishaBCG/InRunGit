using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class MoveDirection : MonoBehaviour
{

    [SerializeField] private SceneController sceneController;


    protected Vector3 yTranslate = new Vector3(0, 0.001f, 0);
    protected Vector3 zTranslate = new Vector3(0, 0, -1f);
    protected static float speed =5;
    private float speedMultiplier = 0.01f;
    protected float maxZRange = 20f;
    protected static float canGo = 1;
    // Start is called before the first frame update
    void Awake()
    {
  
        StartCoroutine(UpdateSpeed());
    }

    private void Start()
    {
            canGo = 1;
            speed = 5;
    }
    private void Update()
    {
        if (sceneController.gameOver == true)
            canGo = 0;

    }
    private IEnumerator UpdateSpeed()
    {

        //скорость можно сделать больше, 100 не так быстро но для тестов норм
        while (speed < 100)
        {
            yield return speed += speed * Time.deltaTime * speedMultiplier;
       
        }

    }

    protected void Move()
    {

            transform.Translate(yTranslate * Time.deltaTime * canGo);
            transform.Translate(zTranslate * Time.deltaTime * speed *canGo);
        

    }


}
