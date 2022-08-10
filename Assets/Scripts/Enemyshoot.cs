using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshoot : MonoBehaviour
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
        gameObject.transform.position += transform.forward * speed * Time.deltaTime;

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Movement pl = other.gameObject.GetComponent<Movement>();
            pl.life -= 20;
        } 
    }
}
