 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWheelControl : MonoBehaviour
{
    public float speed=6.0f;

   // public float turnSpeed=3.0f;

    public WheelCollider wheel_4;
    public WheelCollider wheel_3;
    public WheelCollider wheel_2;
    public WheelCollider wheel_1;
    
    public Transform model_wheel_4;
    public Transform model_wheel_3;
    public Transform model_wheel_2;
    public Transform model_wheel_1;
    // Start is called before the first frame update
    void Start()
    {
        wheel_4.steerAngle = 45;
        wheel_3.steerAngle = -45;
        wheel_2.steerAngle = -45;
        wheel_1.steerAngle = 45;
    }

    // Update is called once per frame
    void Update()
    {
        wheel_4.brakeTorque = 10000000;
        wheel_3.brakeTorque = 10000000;
        wheel_2.brakeTorque = 10000000;
        wheel_1.brakeTorque = 10000000;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            ForWard();
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            Turn();
        else
        {
            wheel_4.motorTorque = 0;
            wheel_3.motorTorque = 0;
            wheel_2.motorTorque = 0;
            wheel_1.motorTorque = 0;
        }
    }

    void ForWard()
    {
        float front = Input.GetAxis("Vertical");
        wheel_4.motorTorque = -front * speed *10000;
        wheel_3.motorTorque = -front * speed *10000;
        wheel_2.motorTorque = -front * speed *10000;
        wheel_1.motorTorque = -front * speed *10000;
        
        wheel_4.brakeTorque = 0;
        wheel_3.brakeTorque = 0;
        wheel_2.brakeTorque = 0;
        wheel_1.brakeTorque = 0;

       /* WheelsModel(model_wheel_4, wheel_4);
        WheelsModel(model_wheel_3, wheel_3);
        WheelsModel(model_wheel_2, wheel_2);
        WheelsModel(model_wheel_1, wheel_1);*/
        
    }

    void Turn()
    {
        float front = Input.GetAxis("Horizontal");
        wheel_4.motorTorque = -front * speed * 1.4f *10000;
        wheel_3.motorTorque = front * speed * 1.4f *10000;
        wheel_2.motorTorque = front * speed * 1.4f *10000;
        wheel_1.motorTorque = -front * speed * 1.4f *10000;
        
        wheel_4.brakeTorque = 0;
        wheel_3.brakeTorque = 0;
        wheel_2.brakeTorque = 0;
        wheel_1.brakeTorque = 0;
        
     /*   WheelsModel(model_wheel_4, wheel_4);
        WheelsModel(model_wheel_3, wheel_3);
        WheelsModel(model_wheel_2, wheel_2);
        WheelsModel(model_wheel_1, wheel_1);*/

    }

    void WheelsModel(Transform wheelMo, WheelCollider wheel)
    {
        Vector3 pos = wheelMo.position;
        Quaternion rot = wheelMo.rotation;

        wheel.GetWorldPose(out pos, out rot);
        wheelMo.position = pos;
        wheelMo.rotation  = rot;
    }
}
