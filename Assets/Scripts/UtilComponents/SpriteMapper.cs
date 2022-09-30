using System;
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
        public IDictionary<string, Sprite> hardCodeSprites = new Dictionary<string, Sprite>();
        public IDictionary<string, Sprite> additionalSprites = new Dictionary<string, Sprite>();
        public IDictionary<string, Sprite> map = new Dictionary<string, Sprite>();

        private SpriteRenderer _renderer;
        private bool _hasStarted;

        private void BuildHardCoded()
        {
            if (names.Length != sprites.Length) throw new ArgumentException("Names and sprites must be same length");
            for (var i = 0; i < names.Length; i++)
            {
                hardCodeSprites.Add(names[i], sprites[i]);
            }
        }
        
        public void Rebuild()
        {
            Debug.Log("SpriteMapper Rebuild: " + additionalSprites.Count + " from additions, "
                        + hardCodeSprites.Count + " from hardcoded");
            map = new Dictionary<string, Sprite>(additionalSprites);
            foreach (var s in hardCodeSprites)
            {
                map.Add(s);
            } 
        }
        
        private void Start()
        {
            if (_hasStarted) return;
            _hasStarted = true;
            _renderer = GetComponent<SpriteRenderer>();
            BuildHardCoded();
            Rebuild();
        }

        public void Switch(string key)
        {
            if (!_hasStarted) Start();
            if (!map.ContainsKey(key)) throw new ArgumentException("No sprite for key: " + key);
            _renderer.sprite = map[key];
        }
    }
}