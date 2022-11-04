using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;


public class Movement : MonoBehaviour
{
    public float life = 180f;

    public Transform tra; //结束重置

    private GameObject EndingCanvas; //结束
    public GameObject EndingBUtton;
    
    //Buff设置
    public GameObject BuffPre;
    public  bool BUFexist = true;
    public float BufExTime = 15f;
    public GameObject Bullet;

    //增益时间
    public float BuffTime = 8f;
    private bool GetBuff = false;

    // Start is called before the first frame update
    void Start()
    {
        EndingCanvas = GameObject.Find("EndingText");
        EndingBUtton = GameObject.Find("Reset");
        EndingCanvas.SetActive(false);
        EndingBUtton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, tra.position, 1000);
           // Debug.Log("YOU Lose!");
           EndingCanvas.SetActive(true);
           EndingBUtton.SetActive(true);
        }

        if (BUFexist == false)
            BuffTime -= Time.deltaTime;
        
        if (GetBuff == true && BuffTime <0)
        {   GameObject.Find("底盘").GetComponent<Followed>().speed /= 1.2f;
            Bullet.GetComponent<Shoot>().speed /= 1.2f;
            GetBuff = false ;
            // BuffTime = 8f;
        }
    }
    
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Buff")
        {
            Destroy( collision.gameObject  );
            BUFexist  = false;
            BufExTime = 15f;
            BuffTime = 8f;
            
            //增益效果
           if (BuffTime > 0)
            {
                GameObject.Find("底盘").GetComponent<Followed>().speed *= 1.2f;
                Bullet.GetComponent<Shoot>().speed *= 1.2f;
                GetBuff = true;
            }
           
        }
        
    }

}
