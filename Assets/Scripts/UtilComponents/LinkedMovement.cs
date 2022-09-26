using UnityEngine;

namespace UtilComponents
{
    public class LinkedMovement : MonoBehaviour
    {
        public GameObject other;
        public float factor;
        private Vector3 _myStartingPos;
        private Vector3 _otherStartingPos;
        
        private void Start()
        {
            _myStartingPos = transform.position;
            _otherStartingPos = other.transform.position;
        }
        
        private void LateUpdate()
        {
            transform.position = _myStartingPos + (other.transform.position - _otherStartingPos) * factor;
        }
    }
}