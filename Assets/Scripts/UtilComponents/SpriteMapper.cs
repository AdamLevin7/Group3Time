using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilComponents
{
    public class SpriteMapper : MonoBehaviour
    {
        /**
         * Do not add to `names` and `sprites` in your code.
         * Instead use `additions`.
         */
        public string[] names;
        public Sprite[] sprites;
        public IDictionary<string, Sprite> additions = new Dictionary<string, Sprite>();
        public IDictionary<string, Sprite> map = new Dictionary<string, Sprite>();

        public void Rebuild()
        {
            if (names.Length != sprites.Length) throw new ArgumentException("Names and sprites must be same length");
            Debug.Log("SpriteMapper Rebuild: " + additions.Count + " from additions, "
                        + names.Length + " from names/sprites");
            map = new Dictionary<string, Sprite>(additions);
            for (var i = 0; i < names.Length; i++)
            {
                map[names[i]] = sprites[i];
            }
        }
        
        private void Start()
        {
            Rebuild();
        }
    }
}