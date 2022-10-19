using UnityEngine;

namespace UtilComponents
{
    public class PointAtCursor : MonoBehaviour
    {

        private void Update()
        {
            if (!GlobalState.mainCamera) return;
            var mousePosition = GlobalState.mainCamera.ScreenToWorldPoint(Input.mousePosition);
            var direction = mousePosition - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }
}