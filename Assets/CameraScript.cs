using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float Speed = 50f;
    bool isTouchingLeft = false;
    bool isTouchingRight = false;
    void Update()
    {
        isTouchingLeft = transform.position.x < -20;
        isTouchingRight = transform.position.x > 20;
        float xAxisValue = Input.GetAxis("Horizontal") * Speed;
        if(!isTouchingLeft && !isTouchingRight)
        {
            move(xAxisValue);
        }
        else if(!isTouchingRight && isTouchingLeft && xAxisValue > 0)
        {
            move(xAxisValue);
        } else if(!isTouchingLeft && isTouchingRight && xAxisValue < 0)
        {
            move(xAxisValue);
        }
    }

    void move(float xAxisValue)
    {
        transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y, transform.position.z);
    }

}