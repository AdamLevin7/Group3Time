using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static Vector2Int PosToTilemapPosition(Vector3 pos, float tileSize)
    {
        return new Vector2Int(Mathf.FloorToInt(pos.x / tileSize), Mathf.FloorToInt(pos.y / tileSize));
    }
    
    public static Vector2 TilemapPositionToPos(Vector2Int pos, float tileSize)
    {
        return new Vector2(pos.x * tileSize + tileSize / 2, pos.y * tileSize + tileSize / 2);
    }

    /**
         * Recursively find components on child GameObjects.
         * @param T The type of component to find.
         * @param start The GameObject to start the search from.
         * @param depthLimit The maximum depth to search. Prevents infinite loops (if that ever happens).
         * 
         * Generics, generics everywhere! - Me, while writing this
         */
    public static IList<T> TraverseForComponents<T>(GameObject start, int depthLimit = 5, int depth = 0)
    {
        var components = new List<T>();
        components.AddRange(start.GetComponents<T>());
        if (depth >= depthLimit)
        {
            Debug.LogWarning("Utilities TraverseForComponents: Depth limit (" + depthLimit + ") reached");
            return components;
        }
        foreach (Transform child in start.transform)
        {
            components.AddRange(TraverseForComponents<T>(child.gameObject, depthLimit, depth + 1));
        }
        Debug.Log("Utilities TraverseForComponents: Found " + components.Count + " components of type " + typeof(T).Name);
        return components;
    }
}