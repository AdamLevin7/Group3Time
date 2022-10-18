using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletMotion : MonoBehaviour
{
    private string _direction;

    public void SetDirection(string direction)
    {
        _direction = direction;
    }

    private static readonly IDictionary<string, Vector2> MapNameToDirection = new Dictionary<string, Vector2>();

    static BulletMotion()
    {
        MapNameToDirection.Add("up", Vector2.up);
        MapNameToDirection.Add("down", Vector2.down);
        MapNameToDirection.Add("left", Vector2.left);
        MapNameToDirection.Add("right", Vector2.right);
    }

    private void Update()
    {
        transform.Translate(MapNameToDirection[_direction]);
    }
}