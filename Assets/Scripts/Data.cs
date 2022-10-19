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

        MapDirectionNameToVector.Add("up", Vector2.up);
        MapDirectionNameToVector.Add("down", Vector2.down);
        MapDirectionNameToVector.Add("left", Vector2.left);
        MapDirectionNameToVector.Add("right", Vector2.right);
        
        MapDirectionNameToRotation.Add("up", Quaternion.Euler(0, 0, 90));
        MapDirectionNameToRotation.Add("down", Quaternion.Euler(0, 0, -90));
        MapDirectionNameToRotation.Add("left", Quaternion.Euler(0, 0, 180));
        MapDirectionNameToRotation.Add("right", Quaternion.Euler(0, 0, 0));
    }

    public static readonly KeyCode[] MovementKeys = {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D};
    public static readonly IDictionary<KeyCode, string> KeyToSprite = new Dictionary<KeyCode, string>();
    public static readonly IDictionary<KeyCode, Vector2> KeyToDirection = new Dictionary<KeyCode, Vector2>();
    public static readonly IDictionary<string, Vector2> MapDirectionNameToVector = new Dictionary<string, Vector2>();
    public static readonly IDictionary<string, Quaternion> MapDirectionNameToRotation = new Dictionary<string, Quaternion>();
}