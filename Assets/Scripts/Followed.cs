using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Followed : MonoBehaviour
{
    public float kp = 0;
    public float ki = 0; 
    public float kd = 0;
    
    private float totalDelta = 0;
    private float LastDelta = 0;
    public GameObject target;

    private float expTurnSpeed = 20.0f; 
    private float turnSpeed = 0f;
    public float maxTurnSpeed = 20.0f;
    
    private float horizontalInput;
    private float verticalInput;
    public float speed = 6.0f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        
        float delta = target.transform.eulerAngles.y - gameObject.transform.eulerAngles.y;
        if (delta < -180)
            delta += 360;
        if (delta > 180)
            delta -= 360;

        totalDelta += delta * Time.time;
        float delatRate = (delta - LastDelta) / Time.time;
        LastDelta = delta;

        expTurnSpeed = delta * kp + totalDelta * ki + delatRate * kd;
        turnSpeed = Mathf.Clamp(expTurnSpeed, -maxTurnSpeed, maxTurnSpeed);
        Quaternion rot=Quaternion.AngleAxis(turnSpeed * Time.deltaTime,Vector3.up);
        gameObject.transform.rotation *= rot;
        
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(-Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.left * Time.deltaTime * speed * horizontalInput);
        
    }
}
