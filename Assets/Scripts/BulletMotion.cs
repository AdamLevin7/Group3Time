using UnityEngine;

public class BulletMotion : MonoBehaviour
{
    public float bulletSpeed;

    public void SetDirection(string direction)
    {
    }

    private void Start()
    {
        Invoke(nameof(SelfDestruct), 1);
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * (Time.deltaTime * bulletSpeed));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        SelfDestruct();
    }
}