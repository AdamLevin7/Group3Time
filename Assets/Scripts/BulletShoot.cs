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
        
        if (Input.GetMouseButtonDown(0))  // [0 | 2] left/right; 1 = depress scroll wheel
        {
            if (!GlobalState.mainCamera) return;
            var mousePosition = GlobalState.mainCamera.ScreenToWorldPoint(Input.mousePosition);
            var direction = mousePosition - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var created = Instantiate(bulletPrefab);
            // ReSharper disable once Unity.InefficientPropertyAccess
            created.transform.position = transform.position;
            Debug.Log(_myController.lastDirection);
            created.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            created.GetComponent<BulletMotion>().SetDirection(_myController.lastDirection);
            
        }
        
    }
}
