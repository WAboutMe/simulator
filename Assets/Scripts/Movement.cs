using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public float life = 180f;

    public float speed = 6.0f;
    public float turnSpeed = 25.0f;
    private float horizontalInput;
    private float verticalInput;

    public Transform tra;

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

    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        if (life <= 0)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, tra.position, 1000);
            Debug.Log("YOU Lose!");
        }

        if (BUFexist == false)
            BuffTime -= Time.deltaTime;
        
        if (GetBuff == true && BuffTime <0)
        {   speed /= 1.2f;
            turnSpeed /= 1.2f;
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
                speed *= 1.2f;
                turnSpeed *= 1.2f;
                Bullet.GetComponent<Shoot>().speed *= 1.2f;
                GetBuff = true;
            }
           
        }
       
        

    }
}
