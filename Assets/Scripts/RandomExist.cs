using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomExist : MonoBehaviour
{
    public GameObject BuffPrefab;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(BuffPrefab  , new Vector3(UnityEngine.Random.Range(-6, 6f), -0.35f, UnityEngine.Random.Range(-4, 4f)),Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        player.GetComponent<Movement>().BufExTime-= Time.deltaTime;
        if (player.GetComponent<Movement >().BUFexist == false && player.GetComponent<Movement>().BufExTime<0)
        {
            Instantiate(BuffPrefab  , new Vector3(UnityEngine.Random.Range(-6, 6f), -0.35f, UnityEngine.Random.Range(-4, 4f)),Quaternion.identity);
            player .GetComponent<Movement >().BUFexist =true  ;
        }
    }
}
