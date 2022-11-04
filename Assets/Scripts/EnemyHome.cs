using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHome : MonoBehaviour
{
    public int life = 200;

    private GameObject _endingText;
    // Start is called before the first frame update
    void Start()
    {
        _endingText = GameObject.Find("EndingText(Win)");
        _endingText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
            // Debug.Log("YOU WIN !!!");
        {
            _endingText.SetActive(false);
            GameObject.Find("底盘").GetComponent<Followed>().speed=0;
            GameObject.Find("Standard").GetComponent<Movement>().EndingBUtton.SetActive(true);
        }

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && GameObject.Find("Sentry").GetComponent<AutoMove>().life <= 0)
            life -= 20;
    }
}
