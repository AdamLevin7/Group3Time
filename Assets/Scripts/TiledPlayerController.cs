using System.Collections.Generic;
using UnityEngine;
using UtilComponents;

public class TiledPlayerController : MonoBehaviour
{
    public Vector2Int startTilePos;
    public Vector2 actualPos;
    
    public float lerpFactor; // per second

    public string direction;
    // expects up, down, left, right
    private SpriteMapper _mapper;
    
    private void Start()
    {
        var localTransform = transform;
        localTransform.position = new Vector3(startTilePos.x + 0.5f, startTilePos.y + 0.5f);
        actualPos = localTransform.position;
        _mapper = GetComponent<SpriteMapper>();
    }

    private void SmoothMoves()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(actualPos.x, actualPos.y), lerpFactor * Time.deltaTime);
    }

    private static readonly KeyCode[] MovementKeys = {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D};
    private static readonly IDictionary<KeyCode, string> KeyToSprite = new Dictionary<KeyCode, string>();
    private static readonly IDictionary<KeyCode, Vector2> KeyToDirection = new Dictionary<KeyCode, Vector2>();

    static TiledPlayerController()  // ooh static ctor
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

    private void Update()
    {
        SmoothMoves();
        foreach (var key in MovementKeys)
        {
            if (!Input.GetKeyDown(key)) continue;
            _mapper.Switch(KeyToSprite[key]);
            // warp to prevent diagonal weirdness, TODO better solution, like input buffering?
            direction = KeyToSprite[key];
            transform.position = new Vector3(actualPos.x, actualPos.y);
            actualPos += KeyToDirection[key];
        }
    }
}