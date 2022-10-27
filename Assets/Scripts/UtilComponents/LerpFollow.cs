using UnityEngine;

namespace UtilComponents
{
    public class LerpFollow : MonoBehaviour
    {
        public float lerpFactor = 10f;

        public GameObject target;
    
        // Start is called before the first frame update
        void Start()
        {
            var vector3 = target.transform.position;
            transform.position = new Vector3(vector3.x, vector3.y, transform.position.z);
        }

        // Update is called once per frame
        void Update()
        {
            var position = transform.position;
            var vector3 = Vector3.Lerp(position, target.transform.position, lerpFactor * Time.deltaTime);
            transform.position = new Vector3(vector3.x, vector3.y, position.z);
        }
    }
}
