using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{
    public float movementSpeed = 5f;
    int health = 35;
    STATES currState = STATES.WALKING;
    DIRECTION facing;
    enum DIRECTION
    {
        LEFT,
        RIGHT
    }

    enum STATES
    {
        ATTACKING,
        WALKING,
        DYING,
        IDLE
    }

    void Start()
    {
        
        if(transform.position.x > 0)
        {
            facing = DIRECTION.LEFT;
        } else if (transform.position.x < 0)
        {
            facing = DIRECTION.RIGHT;
        }

        setDirection(facing);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("Curr State: " + currState);
        if(currState == STATES.WALKING)
        {
            transform.position = new Vector3(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Tower")
        {
            currState = STATES.ATTACKING;
        } else if(col.gameObject.tag == "Skeleton")
        {
            currState = STATES.IDLE;
        }
    }

    void setDirection(DIRECTION facingDirection)
    {
        if(facingDirection == DIRECTION.LEFT)
        {
            movementSpeed = movementSpeed * -1;
        } 
        else
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }

    }
}
