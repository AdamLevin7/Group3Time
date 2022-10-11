using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key.SpaceBar)
        for(int i = 0; i < 10; i++)
        {
            transform.Translate(new Vector2(speed, 0));
        }
    }
}
