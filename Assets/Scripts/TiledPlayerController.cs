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

    private void Update()
    {
        SmoothMoves();
        foreach (var key in Data.MovementKeys)
        {
            if (!Input.GetKeyDown(key)) continue;
            _mapper.Switch(Data.KeyToSprite[key]);
            // warp to prevent diagonal weirdness, TODO better solution, like input buffering?
            direction = Data.KeyToSprite[key];
            transform.position = new Vector3(actualPos.x, actualPos.y);
            actualPos += Data.KeyToDirection[key];
        }
    }
}