// Is this bad practice? I have no idea. - Miles

using System.Collections.Generic;
using UnityEngine;
using UtilComponents;

public class GlobalState : MonoBehaviour
{
    // TEMPORARY
    public float timerMax;
    public float timerStart; 
    public float timerSpeed; 
    
    public static GlobalState instance;

    private ICappableTimer _levelTimer;
    public ICappableTimer LevelTimer
    {
        get => _levelTimer;
        set { _levelTimer = value; Synchronize(); }
    }

    public void Synchronize()
    {
        foreach (var timer in timerDisplays)
        {
            timer.SetReference(_levelTimer);
        }
    }

    public IList<ITimerDisplay> timerDisplays = new List<ITimerDisplay>();

    private void Start()
    {
        instance = this;
        LevelTimer = new SimpleCappableTimer();
        LevelTimer.SetMaximum(timerMax);
        LevelTimer.Set(timerStart);
        LevelTimer.SetTimeScale(timerSpeed);
        
        LevelTimer.Start();
    }

    private void Update()
    {
        LevelTimer.Update();
    }
}