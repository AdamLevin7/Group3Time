using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public float speed;

    public GameObject bulletPrefab;
    private TiledPlayerController _myController;
    // Start is called before the first frame update
    void Start()
    {
        _myController = GetComponent<TiledPlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var created = Instantiate(bulletPrefab);
            created.transform.position = transform.position;
            Debug.Log(_myController.direction);
            created.transform.rotation = Data.MapDirectionNameToRotation[_myController.direction];
            created.GetComponent<BulletMotion>().SetDirection(_myController.direction);
            
        }
        
    }
}
