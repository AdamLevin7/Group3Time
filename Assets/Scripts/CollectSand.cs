using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSand : MonoBehaviour
{
    private int numSand;
    private GameObject[] sand;
    // Start is called before the first frame update
    void Start()
    {
        numSand = 0;
        sand = GameObject.FindGameObjectsWithTag("Sand");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sand"))
        {
            numSand++;
            Destroy(collision.gameObject);
        }
        
    }
}
