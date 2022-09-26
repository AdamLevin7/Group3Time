using Abstraction;
using UnityEngine;

namespace UtilComponents
{
    public class SimpleCappableTimer : ICappableTimer
    {
        private float _time;
        private float _maxTime;
        private bool _running;
        private float _timeScale = 1f;

        public float GetTimeScale() => _timeScale;
        
        public void SetTimeScale(float timeScale) => _timeScale = timeScale;

        public float GetSeconds() => _time;

        public void Set(float seconds) => _time = seconds;

        public void Add(float seconds)
        {
            _time += seconds;
            if (_time > _maxTime) _time = _maxTime;
        }

        public void Pause() => _running = false;

        public void Start() => _running = true;
        
        public bool IsRunning() => _running;
        
        public void Update()
        {
            if (!_running) return;
            _time -= Time.deltaTime * _timeScale;
            if (_time >= 0) return;
            _time = 0;
        }

        public void SetMaximum(float maximumTime) => _maxTime = maximumTime;

        public double GetMaximum() => _maxTime;
    }
}