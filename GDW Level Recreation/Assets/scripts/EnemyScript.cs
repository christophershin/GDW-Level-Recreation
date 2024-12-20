using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyScript : MonoBehaviour
{
    public float EnemySpeed;
    public float Wobble;
    public float PlayerPos;
    public float BossPos;

    public float xpos;
    public float ypos;
    public float startY;

    public bool CanSwoop = true;
    public bool SwoopFinished = false;
    public bool SwoopValleyed = false;

    public float SwoopTimer;

    public GameObject Player;

    //public PlayerHP HP;

    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        xpos = transform.position.x;
        ypos = transform.position.y;
        //HP = gameObject.find("Player").GetComponent<PlayerHP>;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (gameObject.CompareTag("Enemy"))
        {
            transform.position = new Vector3(xpos - EnemySpeed, ypos, 0.0f);
            xpos = transform.position.x;
        }
        if (gameObject.CompareTag("Enemy2"))
        {
            transform.position = new Vector3(xpos - EnemySpeed, ypos - Wobble, 0.0f);
            xpos = transform.position.x;
            ypos = transform.position.y;
            if (Math.Abs(startY - ypos) >= 1.0f)
            {
                Wobble = Wobble * -1;
            }
        }
        if (gameObject.CompareTag("Boss"))
        {
            if(ypos > startY)
            {
                transform.position = new Vector3(xpos - EnemySpeed, ypos - Wobble, 0.0f);
            }
            if (ypos < startY)
            {
                transform.position = new Vector3(xpos - EnemySpeed, ypos + Wobble, 0.0f);
            }
            Swoop();
        }
        if (SwoopTimer > 0.00f)
        {
            SwoopTimer = SwoopTimer - 0.01f;
        }
        else if (SwoopTimer <= 0.00f)
        {
            SwoopFinished = false;
            CanSwoop = true;
        }
    }

    void Update()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            ypos = transform.position.y;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Boss"))
        {
            EnemySpeed = EnemySpeed * -1;
        }
        //if (Collision.gameObject.CompareTag("Player"))
        //{
        //  
        //}
    }

    void Swoop()
    {
        if (CanSwoop = true && Player.transform.position.x - gameObject.transform.position.x < 3)
        {
            CanSwoop = false;
            PlayerPos = Player.transform.position.y;
            BossPos = gameObject.transform.position.y;
        }
        if (CanSwoop == false && SwoopFinished == false)
        {
            if (PlayerPos < gameObject.transform.position.y && SwoopValleyed == false)
            {
                transform.position = new Vector3(xpos, ypos - Wobble * 5, 0.0f);
            }
            else if (SwoopValleyed == true && gameObject.transform.position.y < BossPos)
            {
                transform.position = new Vector3(xpos, ypos + Wobble * 5, 0.0f);
            }
            else
            {
                SwoopFinished = true;
                SwoopTimer = 5.0f;
            }
        }
    }
}
