using UnityEngine;

namespace UtilComponents
{
    public class RandomPosition : MonoBehaviour
    {
        public float minX;
        public float maxX;
        public float minY;
        public float maxY;
        // Start is called before the first frame update
        void Start()
        {
            transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
