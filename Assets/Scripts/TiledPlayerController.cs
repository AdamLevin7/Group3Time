using System;
using UnityEngine;

public class TiledPlayerController : MonoBehaviour
{
    public Vector2Int startTilePos;
    public int lerpFactor;
    
    private void Start()
    {
        transform.position = new Vector3(startTilePos.x + 0.5f, startTilePos.y + 0.5f);
        InvokeRepeating(nameof(Tenths), 0, 0.1f); // best practices: use nameof(...)
    }

    private void Tenths()
    {
        
    }

    private void Update()
    {
        
    }
}