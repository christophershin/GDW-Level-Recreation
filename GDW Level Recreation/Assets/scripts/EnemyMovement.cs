using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public float moveAmount;
    public int enemyDamage = 1;

    public float invincibleTimeMax = 1;
    private float invincibleTimer; 
    private bool damageBool = false;
    private GameObject player;

    public Rigidbody2D enemy;
    private Vector2 Movement;
    private float OriginalX;
    private float OriginalY;
    private float endX;
    private float endY;

    private bool atEnd;

    public bool moveup;
    public bool movedown;
    public bool moveleft;
    public bool moveright;

    private bool isFacingRight;

    public int health;
    public bool torch;
    public bool imp;
    public bool skull;
    public bool soul;
    public bool cacodemon;

    private void Start()
    {
        OriginalX = transform.position.x;
        OriginalY = transform.position.y;
        atEnd = false;
        isFacingRight = false;

        if (moveup)
        {
            endY = OriginalY + moveAmount;
        }
        if (movedown)
        {
            endY = OriginalY - moveAmount;
        }
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

        
        
        invincibleTimer-=Time.deltaTime;

        if (moveup)
        {
            if (!atEnd && transform.position.y < endY)
            {
                MoveUP();
            }
            else if (transform.position.y >= endY)
            {
                atEnd = true;
            }
            if (atEnd && transform.position.y > OriginalY)
            {
                MoveDOWN();
            }
            else if (transform.position.y <= OriginalY)
            {
                atEnd = false;
            }
        }

        if (movedown)
        {
            if (!atEnd && transform.position.y > endY)
            {
                MoveDOWN();
            }
            else if (transform.position.y <= endY)
            {
                atEnd = true;
            }
            if (atEnd && transform.position.y < OriginalY)
            {
                MoveUP();
            }
            else if (transform.position.y >= OriginalY)
            {
                atEnd = false;
            }
        }

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

        DamagePlayer(player);

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

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){

            damageBool = true;
            player = other.gameObject;
        }
    }





    private void DamagePlayer(GameObject inst){

        if(invincibleTimer<=0 && damageBool == true)
        {
            inst.gameObject.GetComponent<PlayerController>().PlayerHP-=enemyDamage;
            invincibleTimer = invincibleTimeMax;
        }else if(invincibleTimer>0){
            damageBool = false;
        }

    }
}

