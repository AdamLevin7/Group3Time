using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    static Data()
    {
        KeyToDirectionName.Add(KeyCode.W, "up");
        DirectionNameToDirectionVector.Add("up", Vector2.up);
        KeyToDirectionName.Add(KeyCode.S, "down");
        DirectionNameToDirectionVector.Add("down", Vector2.down);
        KeyToDirectionName.Add(KeyCode.A, "left");
        DirectionNameToDirectionVector.Add("left", Vector2.left);
        KeyToDirectionName.Add(KeyCode.D, "right");
        DirectionNameToDirectionVector.Add("right", Vector2.right);
    }

    public static readonly KeyCode[] MovementKeys = {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D};
    public static readonly IDictionary<KeyCode, string> KeyToDirectionName = new Dictionary<KeyCode, string>();
    public static readonly IDictionary<string, Vector2> DirectionNameToDirectionVector =
        new Dictionary<string, Vector2>();
}