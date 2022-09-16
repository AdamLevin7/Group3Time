using System;
using UnityEngine;

public class Control : MonoBehaviour
{
    private bool _lastSpace = false;
    public GameObject timer;
    public float incAmount;
    private ITimerDisplay _timerControl;
    private void Start()
    {
        _timerControl = timer.GetComponent<ITimerDisplay>();
    }

    private void Update()
    {
        var space = Input.GetKeyDown(KeyCode.Space);
        if (space)
        {
            Debug.Log("Space pressed");
            _timerControl.Refill(incAmount);
        }
        _lastSpace = space;
    }
}
