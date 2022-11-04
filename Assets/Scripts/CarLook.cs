using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLook : MonoBehaviour
{
    public float sensitivityHor = 9.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Input.GetAxis("Mouse X") * sensitivityHor;
        float rotationY = delta + transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(0, rotationY, 0);

        gameObject.transform.position = GameObject.Find("底盘").transform.position;
    }
}
