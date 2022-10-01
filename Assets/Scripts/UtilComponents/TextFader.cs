using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace UtilComponents
{
    public class TextFader : MonoBehaviour
    {
        private IList<TextMeshProUGUI> _texts;
        private readonly IDictionary<int, float> _baseValues = new Dictionary<int, float>();
        private readonly IDictionary<int, float> _startValues = new Dictionary<int, float>();
        private readonly IDictionary<int, float> _targetValues = new Dictionary<int, float>();
        private float _duration;
        private float _currentTime;
        
        public void RecomputeChildren()
        {
            _texts = Utilities.TraverseForComponents<TextMeshProUGUI>(gameObject);
        }
        
        public void UpdateDefaults(bool dropOld = false)
        {
            if (dropOld)
            {
                _baseValues.Clear();
                _targetValues.Clear();
                _startValues.Clear();
            }
            foreach (var tmpComponent in _texts)
            {
                var id = tmpComponent.GetInstanceID();
                _baseValues[id] = tmpComponent.alpha;
                _targetValues[id] = _baseValues[id];
                _startValues[id] = _baseValues[id];
            }
        }
        
        private void Start()
        {
            RecomputeChildren();
            UpdateDefaults(true);
        }
        
        public void FadeTo(float target, float duration)
        {
            _duration = duration;
            _currentTime = 0;
            foreach (var tmpComponent in _texts)
            {
                var id = tmpComponent.GetInstanceID();
                _startValues[id] = tmpComponent.alpha;
                _targetValues[id] = target;
            }
        }

        private void Update()
        {
            if (_duration <= 0) return;
            foreach (var tmpComponent in _texts)
            {
                _currentTime += Time.deltaTime;
                var id = tmpComponent.GetInstanceID();
                var original = _baseValues[id];
                var start = _startValues[id];
                var target = _targetValues[id];
                var progress = Mathf.Lerp(start, target, _currentTime / _duration);
                tmpComponent.alpha = progress * original;
            }
        }
    }
}