using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{


    [SerializeField] private GameObject bullet;
    [SerializeField] private int bulletforce = 50;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            createBullet();


        }






    }


    private void createBullet()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position;
        newBullet.GetComponent<Rigidbody2D>().AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * bulletforce, ForceMode2D.Impulse);

    }






}
