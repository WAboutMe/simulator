using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float speed = 3.0f;
    public Transform Moveposition1;
    public Transform Moveposition2;
    private Vector3 StartPosition;
    private Vector3 EndPosition;
    private bool OnTheMove=false;


    public int life = 180;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = Moveposition1.position;
        EndPosition = Moveposition2.position;
        //this.position = StartPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float delta = speed * Time.deltaTime;

        if (OnTheMove == false)
            this.transform.position = Vector3.MoveTowards(this.transform.position, EndPosition, delta);
        else
            this.transform.position = Vector3.MoveTowards(this.transform.position, StartPosition, delta);

        if (this.transform.position.x == EndPosition.x && this.transform.position.z == EndPosition.z)
            OnTheMove = true;
        else if(this.transform.position.x == StartPosition.x && this.transform.position.z == StartPosition.z)
            OnTheMove=false;
        
        
    }
}
