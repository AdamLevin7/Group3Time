using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public GameObject bullet;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(bullet))
        {
            Destroy(gameObject);
        }
    }
}
