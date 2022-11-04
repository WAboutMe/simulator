using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook1 : MonoBehaviour
{
    public float sensitivityVert = 9.0f;

    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    private float _rotationX = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       _rotationX += Input.GetAxis("Mouse Y") * sensitivityVert;
       _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);
       
       transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
    }
}
