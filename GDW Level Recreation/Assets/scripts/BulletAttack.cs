using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BulletAttack : MonoBehaviour
{
    private GameObject player;


    private void Start()
    {
        player = GameObject.Find("Player");
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Torch")
        {
            player.GetComponent<PlayerController>().playerscore += 10;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.tag == "Imp")
        {
            player.GetComponent<PlayerController>().playerscore += 20;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.tag == "Skull")
        {
            player.GetComponent<PlayerController>().playerscore += 30;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.tag == "LostSoul")
        {
            player.GetComponent<PlayerController>().playerscore += 50;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.tag == "Cacodemon")
        {
            player.GetComponent<PlayerController>().playerscore += 150;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
