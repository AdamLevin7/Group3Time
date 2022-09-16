using System;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class CornerTimer : MonoBehaviour, ITimerDisplay
{
    // Attach to the TMP Text object.
    TextMeshProUGUI textMesh;
    // The time in seconds that the timer will count down from.
    public float startTime = 10;
    public float maxTime;
    public float redAfter;
    public float shakeMax;
    
    private float _currentTime;
    private Random _rng = new Random();

    public float freezeTime = 0;

    private Vector3 _baseBasePos;
    private Vector3 _basePos;
    private float _bumpY = 0;
    
    // Start is called before the first frame update
    private void Start()
    {
        freezeTime = 0;
        _bumpY = 0;
        _baseBasePos = transform.position;
        _basePos = _baseBasePos;
        textMesh = GetComponent<TextMeshProUGUI>();
        _currentTime = startTime;
    }

    public void Bump(float y)
    {
        if (!(Mathf.Abs(y) < Mathf.Abs(_bumpY))) _bumpY = y;
    }
    
    // Update is called once per frame
    private void Update()
    {
        var lastTime = _currentTime;
        if (freezeTime > 0)
        {
            freezeTime -= Time.deltaTime;
        }
        else
        {
            _currentTime -= Time.deltaTime;
        }
        _currentTime = Mathf.Clamp(_currentTime, 0, maxTime);

        if (Mathf.FloorToInt(lastTime) != Mathf.FloorToInt(_currentTime))
        {
            Bump(-5);
        }
        
        if (_currentTime <= redAfter)
        {
            var factor = 1 - _currentTime / redAfter;
            textMesh.color = Color.red * factor + Color.white * (1 - factor);
            var x = _rng.Next(0, 1000) / 1000f * factor * shakeMax;
            var y = _rng.Next(0, 1000) / 1000f * factor * shakeMax;
            var z = _rng.Next(0, 1000) / 1000f * factor * shakeMax;
            _basePos = _baseBasePos + new Vector3(x, y, z);
        }
        else
        {
            textMesh.color = Color.white;
        }
        _bumpY /= 1 + Time.deltaTime * 10;
        transform.position = _basePos + new Vector3(0, _bumpY, 0);
        textMesh.text = _currentTime.ToString("0.00");
    }
    
    public void Refill(float seconds)
    {
        _currentTime += seconds;
        _currentTime = Mathf.Clamp(_currentTime, 0, maxTime);
        freezeTime = 0.1f;
        Bump(-20);
    }
}