using UnityEngine;
using UtilComponents;

public class TiledPlayerController : MonoBehaviour
{
    public Vector2Int startTilePos;
    public float moveSpeed = 10f; // seconds per tile
    private float _movStartTime;
    private Vector2 _movStartPos;
    private Vector2 _movEndPos;
    private bool _keydown;

    public string lastDirection = "right";
    private string _direction = "";

    private string _buffered = "";
    // expects up, down, left, right
    private SpriteMapper _mapper;
    
    private void Start()
    {
        lastDirection = "right";  // Sheesh Unity stop overwriting my public variables
        var localTransform = transform;
        localTransform.position = new Vector3(startTilePos.x + 0.5f, startTilePos.y + 0.5f);
        _movEndPos = localTransform.position;
        _mapper = GetComponent<SpriteMapper>();
    }

    private void Interpolate()
    {
        if (_direction == "") return;
        var c = (Time.time - _movStartTime) / moveSpeed;
        transform.position = Vector2.Lerp(_movStartPos, _movEndPos, c);
        if (c >= 1f) NextDirection();
    }

    private void NextDirection()
    {
        _direction = _buffered;
        _buffered = "";
        if (_direction == "") return;
        ProcessDirectionChange();
    }

    private void Update()
    {
        Interpolate(); // handles animation and buffering queue
        foreach (var key in Data.MovementKeys)
        {
            // buffer if: key is down and not the current direction
            if (Input.GetKey(key)) {
                if (_direction == "")
                {
                    _direction = Data.KeyToDirectionName[key];
                    ProcessDirectionChange();
                }
                else if (_direction != Data.KeyToDirectionName[key])
                {
                    _buffered = Data.KeyToDirectionName[key]; // buffer the next direction, overwrite if needed
                }
                else { /* TODO figure this out */}
            }
        }
    }

    private void ProcessDirectionChange()
    {
        lastDirection = _direction;
        _mapper.Switch(_direction);
        _movStartPos = transform.position;
        _movEndPos = _movStartPos + Data.DirectionNameToDirectionVector[_direction];
        _movStartTime = Time.time;
    }
}