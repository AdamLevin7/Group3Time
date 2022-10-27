using UnityEngine;
using UtilComponents;

public class TiledPlayerController : MonoBehaviour
{
    public Vector2Int startTilePos;
    public Vector2 actualPos;
    
    private float _maxX = 22.5f;
    private float _maxY = -2.5f;
    private float _minX = -3.5f;
    private float _minY = 5.5f;

    private bool _keydown;

    public float lerpFactor = 0.3f; // per second

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
                continue;
            }
            if (Input.GetKey(key) && Time.deltaTime <= 0.0125f) {
                _mapper.Switch(Data.KeyToSprite[key]);
                // warp to prevent diagonal weirdness, TODO better solution, like input buffering?
                direction = Data.KeyToSprite[key];
                if (transform.position.x >= _maxX && key == KeyCode.D) {
                    transform.position = new Vector3(_maxX, actualPos.y);
                } else if (transform.position.y <= _maxY && key == KeyCode.S) {
                    transform.position = new Vector3(actualPos.x, _maxY);
                } else if (transform.position.x <= _minX && key == KeyCode.A) {
                    transform.position = new Vector3(_minX, actualPos.y);
                } else if (transform.position.y >= _minY && key == KeyCode.W) {
                    transform.position = new Vector3(actualPos.x, _minY);
                } else {
                    transform.position = new Vector3(actualPos.x, actualPos.y);
                    actualPos += Data.KeyToDirection[key];
                }
            }
        }
    }
}