using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MoveDirection
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckPos();
    }

    private void OnTriggerEnter(Collider other)
    {
            gameObject.SetActive(false);
    }

    private void CheckPos()
    {
        if(transform.position.z < -maxZRange)
            gameObject.SetActive(false);
    }
}
