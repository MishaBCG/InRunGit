using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveDirection : MonoBehaviour
{
    protected Vector3 yTranslate = new Vector3(0, 0.001f, 0);
    protected Vector3 zTranslate = new Vector3(0, 0, -1f);
    protected float speed;
    private float speedMultiplier = 0.1f;


    private void Awake()
    {
        StartCoroutine(UpdateSpeed());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private IEnumerator UpdateSpeed()
    {

        //скорость можно сделать больше, 100 не так быстро но для тестов норм
        while (speed < 100)
        {
            speed = 5;
            yield return speed += speed * Time.deltaTime * speedMultiplier;
        }

    }

    protected void Move()
    {
        transform.Translate(yTranslate * Time.deltaTime);
        transform.Translate(zTranslate * Time.deltaTime * speed);
    }


}
