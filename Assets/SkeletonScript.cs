using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkeletonScript : MonoBehaviour
{
    enum DIRECTION
    {
        LEFT,
        RIGHT
    }
    public enum STATES
    {
        ATTACKING,
        WALKING,
        DYING,
        IDLE
    }
    public STATES currState;
    DIRECTION facing;
    //Animator animator;
    public float movementSpeed = 5f;
    int health = 35;
    public Animator animator;
    void Start()
    {
        currState = STATES.WALKING;
        //animator = GetComponent<Animator>();
        if (transform.position.x > 0)
        {
            facing = DIRECTION.LEFT;
        } else if (transform.position.x < 0)
        {
            facing = DIRECTION.RIGHT;
        }

        SetDirection(facing);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currState == STATES.WALKING)
        {
            transform.position = new Vector3(transform.position.x + movementSpeed * Time.deltaTime, transform.position.y);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Tower"))
        {
            currState = STATES.ATTACKING;
            ChangeAnimationState(STATES.ATTACKING);
        } else if (col.gameObject.CompareTag("Skeleton") && currState != STATES.ATTACKING)
        {
            currState = STATES.IDLE;
            ChangeAnimationState(STATES.IDLE);
        }
    }

    void SetDirection(DIRECTION facingDirection)
    {
        if (facingDirection == DIRECTION.LEFT)
        {
            movementSpeed = movementSpeed * -1;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }

    }

    void ChangeAnimationState(STATES newState)
    {
        string animName = newState switch
        {
            STATES.ATTACKING => "Skeleton_Attack",
            STATES.WALKING => "Skeleton_Walk",
            STATES.DYING => "Skeleton_Walk",
            STATES.IDLE => "Skeleton_Idle",
            _ => "Skeleton_Idle",
        };

        if (currState== newState)
        {
            animator.Play(animName);
        }
    }


}
