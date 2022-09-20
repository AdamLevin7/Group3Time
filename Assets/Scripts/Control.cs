using System;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameObject timer;
    public float incAmount;

    private void Update()
    {
        var space = Input.GetKeyDown(KeyCode.Space);
        if (space)
        {
            Debug.Log("Space pressed");
            GlobalState.instance.LevelTimer.Add(incAmount);
        }
    }
}
