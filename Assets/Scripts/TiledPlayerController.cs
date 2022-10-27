using UnityEngine;
using UtilComponents;

public class TiledPlayerController : MonoBehaviour
{
    public Vector2Int startTilePos;
    public Vector2 actualPos;
    private bool _keydown;

    private float elapsed = 0.0f;

    public float lerpFactor = 10.0f; // per second

    public string direction = "right";
    // expects up, down, left, right
    private SpriteMapper _mapper;
    
    private void Start()
    {
        direction = "right";  // Sheesh Unity stop overwriting my public variables
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

            if (!Input.GetKey(key)) {
                elapsed = Time.deltaTime;
                continue;
            }
            if (Input.GetKey(key) && elapsed <= 0.01f) {
                _mapper.Switch(Data.KeyToSprite[key]);
                // warp to prevent diagonal weirdness, TODO better solution, like input buffering?
                direction = Data.KeyToSprite[key];
                transform.position = new Vector3(actualPos.x, actualPos.y);
                actualPos += Data.KeyToDirection[key];
            }

            if (elapsed >= 0.5f) {
                elapsed = 0.0f;
            }
        }
    }
}