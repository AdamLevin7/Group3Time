using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public float speed;

    public GameObject bulletPrefab;
    private TiledPlayerController myController;
    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<TiledPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var created = Instantiate(bulletPrefab);
            created.transform.position = transform.position;
            created.GetComponent<BulletMotion>().SetDirection(myController.direction);
        }
        
    }
}
