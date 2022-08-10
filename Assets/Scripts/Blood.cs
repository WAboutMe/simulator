using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Blood : MonoBehaviour
{
    public Slider slider;
    public GameObject Ho;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Ho.GetComponent<EnemyHome>().life;
        gameObject.transform.LookAt(Camera.main.transform);
    }
}
