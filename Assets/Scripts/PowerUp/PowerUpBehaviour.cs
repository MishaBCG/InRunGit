using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour : MoveDirection
{
    private void Awake()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            Move();
            if (transform.position.z < -maxZRange)
                gameObject.SetActive(false);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }    
            
    }

}
