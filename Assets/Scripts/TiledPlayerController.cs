using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager;
using UnityEngine;
using UtilComponents;

public class TiledPlayerController : MonoBehaviour
{
    public Vector2Int startTilePos;
    public Vector2 actualPos;
    
    public float lerpFactor; // per second

    // expects up, down, left, right
    private SpriteMapper _mapper;
    
    private void Start()
    {
        var localTransform = transform;
        localTransform.position = new Vector3(startTilePos.x + 0.5f, startTilePos.y + 0.5f);
        actualPos = localTransform.position;
        _mapper = GetComponent<SpriteMapper>();
    }

    private void Lerps()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(actualPos.x, actualPos.y), lerpFactor * Time.deltaTime);
    }

    private readonly KeyCode[] movementKeys = {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D};
    private static readonly IDictionary<KeyCode, string> keyToSprite = new Dictionary<KeyCode, string>();
    private static readonly IDictionary<KeyCode, Vector2> keyToDirection = new Dictionary<KeyCode, Vector2>();

    static TiledPlayerController()  // ooh static ctor
    {
        keyToSprite.Add(KeyCode.W, "up");
        keyToDirection.Add(KeyCode.W, Vector2.up);
        keyToSprite.Add(KeyCode.S, "down");
        keyToDirection.Add(KeyCode.S, Vector2.down);
        keyToSprite.Add(KeyCode.A, "left");
        keyToDirection.Add(KeyCode.A, Vector2.left);
        keyToSprite.Add(KeyCode.D, "right");
        keyToDirection.Add(KeyCode.D, Vector2.right);
    }

    private void Update()
    {
        Lerps();
        foreach (var key in movementKeys)
        {
            if (!Input.GetKeyDown(key)) continue;
            _mapper.Switch(keyToSprite[key]);
            // warp to prevent diagonal weirdness, TODO better solution, like input buffering?
            transform.position = new Vector3(actualPos.x, actualPos.y);
            actualPos += keyToDirection[key];
        }
    }
}