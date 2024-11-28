using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{


    [SerializeField] private GameObject bullet;
    [SerializeField] private int bulletforce = 1;
    [SerializeField] private float maxUnload = 0.01f;
    [SerializeField] private int MaxAmmo = 40;
    [SerializeField] private float MaxReload = 1f;
    private float reload;
    private int ammo;
    private float unloadSpeed;
    private bool Attack = false;
    private Vector3 offset;
    

    private GameObject playerParent;
    private GameObject ID;






    // Start is called before the first frame update
    void Start()
    {
        ID = this.gameObject;
        ammo = MaxAmmo;
    }

    // Update is called once per frame
    void Update()
    {

        unloadSpeed -= Time.deltaTime;
        reload -= Time.deltaTime;

        // Aiming {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 target = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = target;
        //}

        if(playerParent!=null)
        {
            //follow the player
            transform.position = playerParent.transform.position;
        }


        Shooting();
        Reload();


        
        if(Input.GetMouseButton(0))
        {
            if(ammo>0)
            {
                Attack = true;
            }
                

        }else{
            Attack = false;
            unloadSpeed = 0f;

        }







    }


    private void createBullet()
    {

        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = transform.rotation;
        newBullet.GetComponent<bulletScript>().bulletSpeed = bulletforce;
        newBullet.GetComponent<bulletScript>().parent = ID;

    }


    private void Shooting()
    {

        if(ammo>0 && unloadSpeed<=0f && Attack == true)
        {
            createBullet();
            ammo--;
            unloadSpeed = maxUnload;

        }else{
            reload = MaxReload;
        }

    }

    private void Reload()
    {
        if(ammo<MaxAmmo && !Attack && reload<=0f)
        {
            ammo = MaxAmmo;
            Debug.Log("full");

        }


    }




    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "Player"){

            playerParent = other.gameObject;

        }


    }





}
