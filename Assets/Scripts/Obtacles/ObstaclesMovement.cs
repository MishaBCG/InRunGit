using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMovement : MoveDirection
{
    



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(transform.position.z < -10)
            gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
            collision.gameObject.SetActive(false);

    }

}
