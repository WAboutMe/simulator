using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 20f;
    float lifetime = 6.0f;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {   
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
        gameObject.transform.position += -transform.forward * speed * Time.deltaTime;
        if (GameObject.Find("Standard").GetComponent<Movement>().life <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        { AutoMove ec = other.gameObject.GetComponent<AutoMove>();
        ec.life -= 20;
        //Debug.Log(ec.life);
        if (ec.life <= 0)
        {
            ec.speed = 0;  
        }
        }
    }
    
}
