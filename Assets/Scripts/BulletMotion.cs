using UnityEngine;

public class BulletMotion : MonoBehaviour
{
    private string _direction;

    public void SetDirection(string direction)
    {
        _direction = direction;
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
        transform.Translate(Data.MapDirectionNameToVector[_direction] * Time.deltaTime);
    }
}