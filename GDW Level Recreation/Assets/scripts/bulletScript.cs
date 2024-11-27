using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    
    public float bulletSpeed;
    public float maxTime = 1;
    private float time;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        time = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        time-=Time.deltaTime;

        if(time<=0)
            Destroy(this.gameObject);
        
        transform.position += transform.up * Time.deltaTime * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.layer == 6){
            Destroy(this.gameObject);
        }



    }
}
