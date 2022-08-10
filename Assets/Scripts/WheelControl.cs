using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControl : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        { ForwardWheel(true); }
        if (Input.GetKey(KeyCode.S))
        { ForwardWheel(false); }

        if (Input.GetKey(KeyCode.D))
        { RotWheel(true); }
        if (Input.GetKey(KeyCode.A))
        { RotWheel(false); }
    }

    public void ForwardWheel(bool moveforw)
    {  transform.Rotate(new Vector3(0,0,1 * 360 * Time.deltaTime * (moveforw ? 1 : -1))); }

    public void RotWheel(bool isright)
    { transform.Rotate(Vector3.up*Time.deltaTime*30*(isright?1:-1),Space.World);}
}
