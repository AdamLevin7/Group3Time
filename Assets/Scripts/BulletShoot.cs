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
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)){
            for (int i = 0; i < 10; i++)
            {
                transform.Translate(new Vector2(speed, 0));
            }
            transform.position = player.transform.position;
        }
        
    }
}
