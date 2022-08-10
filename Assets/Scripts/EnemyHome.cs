using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHome : MonoBehaviour
{
    public int life = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
            Debug.Log("YOU WIN !!!");
       
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && GameObject.Find("Sentry").GetComponent<AutoMove>().life <= 0)
            life -= 20;
    }
}
