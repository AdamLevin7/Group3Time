using System;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class CornerTimer : MonoBehaviour, ITimerDisplay
{
    // Attach to the TMP Text object.
    TextMeshProUGUI textMesh;

    private float _currentTime;
    private Vector3 _basePos;
    private float _bumpY = 0;
    private ITimer _timer;
    
    // Start is called before the first frame update
    private void Start()
    {
        _bumpY = 0;
        _basePos = transform.position;
        textMesh = GetComponent<TextMeshProUGUI>();
        
        GlobalState.instance.timerDisplays.Add(this);
        GlobalState.instance.Synchronize();
    }

    public void Bump(float y)
    {
        if (!(Mathf.Abs(y) < Mathf.Abs(_bumpY))) _bumpY = y;
    }
    
    // Update is called once per frame
    private void Update()
    {
        var lastTime = _currentTime;
        _currentTime = _timer.GetSeconds();

        if (Mathf.FloorToInt(lastTime) != Mathf.FloorToInt(_currentTime))
        {
            Bump(-5);
        }
        
        _bumpY /= 1 + Time.deltaTime * 10;
        transform.position = _basePos + new Vector3(0, _bumpY, 0);
        textMesh.text = _currentTime.ToString("0.00");
    }

    public void SetReference(ITimer source)
    {
        _timer = source;
    }
}