using UnityEngine;
using UtilComponents;

public class TiledPlayerController : MonoBehaviour
{
    public Vector2Int startTilePos;
    public float moveSpeed = 0.1f; // seconds per tile, straight
    private float _movStartTime;
    private Vector2 _movStartPos;
    private Vector2 _movEndPos;
    private bool _keydown;

    public string lastDirection = "right";
    private string _direction = "";

    // expects up, down, left, right
    private SpriteMapper _mapper;

    private void Start()
    {
        lastDirection = "right"; // Sheesh Unity stop overwriting my public variables
        var localTransform = transform;
        localTransform.position = new Vector3(startTilePos.x + 0.5f, startTilePos.y + 0.5f);
        _movEndPos = localTransform.position;
        _mapper = GetComponent<SpriteMapper>();
    }

    private void Interpolate()
    {
        var d = (_movEndPos - _movStartPos).magnitude;
        if (_direction == "") return;
        var c = (Time.time - _movStartTime) / (moveSpeed * d);
        transform.position = Vector2.Lerp(_movStartPos, _movEndPos, c);
        if (c >= 1f) NextDirection();
    }

    private void NextDirection()
    {
        _direction = "";
    }

    private void Update()
    {
        Interpolate(); // handles animation and buffering queue
        var motion = Vector2.zero;
        var direction = "";
        foreach (var key in Data.MovementKeys)
        {
            if (!Input.GetKey(key)) continue;
            direction = Data.KeyToDirectionName[key];
            motion += Data.DirectionNameToDirectionVector[direction];
        }

        if (_direction == "" && direction != "")
        {
            _direction = direction;
            lastDirection = _direction;
            _mapper.Switch(_direction);
            _movStartPos = transform.position;
            _movEndPos = _movStartPos + motion;
            _movStartTime = Time.time;
        }
    }
}