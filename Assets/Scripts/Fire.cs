using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{  
    public GameObject ballPrefab;
    public Transform tr;
    
    //发射机构热量
    public float limited = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && limited<=50)
        {
            Instantiate(ballPrefab, tr.position, tr.rotation);
            limited+=10;
        }
        if (Input.GetMouseButtonDown(0) && limited > 50 && GameObject.Find("Standard").GetComponent<Movement>().life>=0)
        {
            Instantiate(ballPrefab, tr.position, tr.rotation);
           GameObject.Find("Standard").GetComponent<Movement>().life -= 90f; 
           limited=50;
        }
        limited /= (Time.fixedDeltaTime *51);
        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(2, 1, 150, 100), "枪口热量" + (float)limited);
    }
}
