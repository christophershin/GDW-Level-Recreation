using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BulletAttack : MonoBehaviour
{
    private GameObject player;
    private GameObject enemy;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (other.GetComponent<EnemyMovement>().torch)
            {
                other.GetComponent<EnemyMovement>().health --;
                if (other.GetComponent<EnemyMovement>().health <= 0)
                {
                    Destroy(other.gameObject);
                    player.GetComponent<PlayerController>().playerscore += 10;
                }
            }
            if (other.GetComponent<EnemyMovement>().imp)
            {
                other.GetComponent<EnemyMovement>().health--;
                if (other.GetComponent<EnemyMovement>().health <= 0)
                {
                    Destroy(other.gameObject);
                    player.GetComponent<PlayerController>().playerscore += 20;
                }
            }
            if (other.GetComponent<EnemyMovement>().skull)
            {
                other.GetComponent<EnemyMovement>().health--;
                if (other.GetComponent<EnemyMovement>().health <= 0)
                {
                    Destroy(other.gameObject);
                    player.GetComponent<PlayerController>().playerscore += 30;
                }
            }
            if (other.GetComponent<EnemyMovement>().soul)
            {
                other.GetComponent<EnemyMovement>().health--;
                if (other.GetComponent<EnemyMovement>().health <= 0)
                {
                    Destroy(other.gameObject);
                    player.GetComponent<PlayerController>().playerscore += 50;
                }
            }
            if (other.GetComponent<EnemyMovement>().cacodemon)
            {
                other.GetComponent<EnemyMovement>().health--;
                if (other.GetComponent<EnemyMovement>().health <= 0)
                {
                    Destroy(other.gameObject);
                    player.GetComponent<PlayerController>().playerscore += 150;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
