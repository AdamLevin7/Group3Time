using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    static Data()
    {
        KeyToSprite.Add(KeyCode.W, "up");
        KeyToDirection.Add(KeyCode.W, Vector2.up);
        KeyToSprite.Add(KeyCode.S, "down");
        KeyToDirection.Add(KeyCode.S, Vector2.down);
        KeyToSprite.Add(KeyCode.A, "left");
        KeyToDirection.Add(KeyCode.A, Vector2.left);
        KeyToSprite.Add(KeyCode.D, "right");
        KeyToDirection.Add(KeyCode.D, Vector2.right);
    }

    public static readonly KeyCode[] MovementKeys = {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D};
    public static readonly IDictionary<KeyCode, string> KeyToSprite = new Dictionary<KeyCode, string>();
    public static readonly IDictionary<KeyCode, Vector2> KeyToDirection = new Dictionary<KeyCode, Vector2>();
}