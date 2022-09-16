using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UtilComponents;

public class SandTimer : MonoBehaviour, ITimerDisplay
{
    [FormerlySerializedAs("sandPart")] public GameObject sandPartPrefab;
    [FormerlySerializedAs("sandBase")] public GameObject sandBasePrefab;
    [FormerlySerializedAs("sandTop")] public GameObject sandTopPrefab;

    public int sandPartsCount;

    private GameObject _sandBase;
    private GameObject _sandTop;
    private IList<GameObject> _sandParts = new List<GameObject>();

    public float startingTimerValue;
    public float maxTimerValue;
    private float _timerValue;

    private void Start()
    {
        _timerValue = startingTimerValue;
        Destroy(_sandBase);
        Destroy(_sandTop);
        foreach (var sandPart in _sandParts) Destroy(sandPart);
        _sandParts.Clear();

        _sandBase = Instantiate(sandBasePrefab, transform);
        _sandTop = Instantiate(sandTopPrefab, transform);
        _sandTop.transform.Translate(0, sandPartsCount - 1, 0);
        Debug.Log(_sandTop.transform.position);

        for (var i = 0; i < sandPartsCount; i++)
        {
            var sandPart = Instantiate(sandPartPrefab, transform);
            sandPart.transform.Translate(0, i, 0);
            _sandParts.Add(sandPart);
        }
        Tick(false);
        InvokeRepeating(nameof(TickDefault), 0.1f, 0.1f);
    }
    private void TickDefault() => Tick();
    private void Tick(bool decTimer=true)
    {
        if (decTimer) _timerValue -= 0.1f;
        _timerValue = Mathf.Clamp(_timerValue, 0, maxTimerValue);
        var segments = Mathf.FloorToInt(_timerValue / maxTimerValue * (sandPartsCount * 8));
        foreach (var sandPart in _sandParts)
        {
            sandPart.GetComponent<SpriteSwapper>().SwapSprite(segments);
            segments -= 8;
        }
    }

    public void Refill(float seconds)
    {
        _timerValue += seconds;
        _timerValue = Mathf.Clamp(_timerValue, 0, maxTimerValue);
        Tick(false);
    }

    private void Update()
    {
    }
}
