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
        if(transform.position.z < -maxZRange)
            gameObject.SetActive(false);
    }


}
