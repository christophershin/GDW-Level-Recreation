using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public float moveAmount;

    public Rigidbody2D enemy;
    private Vector2 Movement;
    private float OriginalX;
    private float endX;

    private bool atEnd;

    public bool moveleft;
    public bool moveright;

    private bool isFacingRight;

    private void Start()
    {
        OriginalX = transform.position.x;
        atEnd = false;
        isFacingRight = false;

        if (moveleft)
        {
            endX = OriginalX - moveAmount;
        }
        if (moveright)
        {
            endX = OriginalX + moveAmount;
        }
    }

    void Update()
    {
        if (moveleft)
        {
            if (!atEnd && transform.position.x > endX)
            {
                MoveLEFT();
            }
            else if (transform.position.x <= endX)
            {
                atEnd = true;
            }
            if (atEnd && transform.position.x < OriginalX)
            {
                MoveRIGHT();
            }
            else if (transform.position.x >= OriginalX)
            {
                atEnd = false;
            }
        }

        if (moveright)
        {
            if (!atEnd && transform.position.x < endX)
            {
                MoveRIGHT();
            }
            else if (transform.position.x >= endX)
            {
                atEnd = true;
            }
            if (atEnd && transform.position.x > OriginalX)
            {
                MoveLEFT();
            }
            else if (transform.position.x <= OriginalX)
            {
                atEnd = false;
            }
        }

        //Normalize the moveInput to have magnitude of 1
        Movement.Normalize();

        enemy.velocity = Movement * moveSpeed;

        Flip();
    }

    private void MoveUP()
    {
        Movement.x = 0f;
        Movement.y = moveSpeed;
    }

    private void MoveDOWN()
    {
        Movement.x = 0f;
        Movement.y = -moveSpeed;
    }

    private void MoveLEFT()
    {
        Movement.x = -moveSpeed;
        Movement.y = 0f;
    }

    private void MoveRIGHT()
    {
        Movement.x = moveSpeed;
        Movement.y = 0f;
    }

    private void Flip()
    {
        if (isFacingRight && atEnd == false || !isFacingRight && atEnd == true)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

