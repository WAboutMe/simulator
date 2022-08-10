using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRay : MonoBehaviour
{
    public float obstacleRange = 5.0f;
    public float fireInterval=0.5f;
    private float timer;
    public float turnSpeed = 3.0f;

    public GameObject ballPrefab;
    public Transform tr;

    private Transform player;
    private float distance;
    private RaycastHit hit;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
       
    }


    // Update is called once per frame
    void Update()
    { timer+=Time.deltaTime;
        distance = Vector3.Distance(transform.position, player.position);
       
        if (distance < obstacleRange)
        {
            if (GameObject.Find("Sentry").GetComponent<AutoMove>().life <= 0)
                return;
            else
            {
                Vector3 dir = player.position - transform.position;
                RotateTo(dir);
                if (timer > fireInterval)
                    if (Checkforward(obstacleRange))
                    {
                        timer = 0;
                        Instantiate(ballPrefab, tr.position, tr.rotation);
                    }
            }
        }
    }


    private void RotateTo(Vector3 dir)
    {
        //Vector3 dir = player.position - transform.position;
        Quaternion target = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation,target,Time.deltaTime*turnSpeed);
    
    }


    private bool Checkforward(float dis)
    {
        if (Physics.Raycast(tr.position, transform.forward, out hit, dis))
        {
            if (hit.collider.transform.root.tag == "Player")
                return true;
        }
      // else if (GameObject.Find("Sentry").GetComponent<AutoMove>().life == 0)
       //    return false;
        return false;
    
    }

}
