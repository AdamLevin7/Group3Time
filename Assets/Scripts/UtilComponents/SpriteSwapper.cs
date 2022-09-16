using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace UtilComponents
{
    public class SpriteSwapper : MonoBehaviour
    {
        public enum OverflowStrategy
        {
            Clamp,
            Wrap,
            Error
        }
        
        public Sprite[] sprites;
        
        private SpriteRenderer _spriteRenderer;

        public OverflowStrategy overflowMode;
        public OverflowStrategy underflowMode;

        private bool _hasStarted = false;
        
        private void Start()
        {
            if (_hasStarted) return;
            _hasStarted = true;
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = sprites[0];
        }
        
        public void SwapSprite(int index)
        {
            if (!_hasStarted) Start();
            if (index < 0)
            {
                switch (underflowMode)
                {
                    case OverflowStrategy.Clamp:
                        index = 0;
                        break;
                    case OverflowStrategy.Wrap:
                        index %= sprites.Length;
                        break;
                    case OverflowStrategy.Error:
                        throw new ArgumentException("Bad index - less than 0");
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } else if (index >= sprites.Length)
            {
                switch (overflowMode)
                {
                    case OverflowStrategy.Clamp:
                        index = sprites.Length - 1;
                        break;
                    case OverflowStrategy.Wrap:
                        index %= sprites.Length;
                        break;
                    case OverflowStrategy.Error:
                        throw new ArgumentException("Bad index - too big");
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            _spriteRenderer.sprite = sprites[index];
        }
    }
}