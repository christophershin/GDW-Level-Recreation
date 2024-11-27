using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{


    [SerializeField] private GameObject bullet;
    [SerializeField] private int bulletforce = 1;
    [SerializeField] private float unloadSpeed;
    private Vector3 offset;
    

    private GameObject playerParent;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Aiming {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 target = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = target;
        //}

        unloadSpeed -= Time.deltaTime;

        if(playerParent!=null)
        {
            //follow the player
            transform.position = playerParent.transform.position;

        }



            

        
        if(Input.GetMouseButton(0))
        {

            createBullet();

        }






    }


    private void createBullet()
    {

        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = transform.rotation;
        newBullet.GetComponent<bulletScript>().bulletSpeed = bulletforce;

    }




    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "Player"){

            playerParent = other.gameObject;

        }


    }





}
