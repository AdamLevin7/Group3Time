using UnityEngine;
using UtilComponents;

public class StartTile : MonoBehaviour
{
    public GameObject player;
    private Vector2Int _tilePos;
    public float timeValue;

    public GameObject startTimerText;
    private TextFader _sttFader;
    public GameObject cornerTimerText;
    private TextFader _cttFader;

    public float cornerShadingWhenOnTile;
    public float cornerShadingWhenOffTile;
    
    public float centerShadingWhenOnTile;
    public float centerShadingWhenOffTile;

    private bool _wasOn;

    private void Start()
    {
        _tilePos = Utilities.PosToTilemapPosition(transform.position, 1);
        transform.position = Utilities.TilemapPositionToPos(_tilePos, 1);
        _sttFader = startTimerText.GetComponent<TextFader>();
        _cttFader = cornerTimerText.GetComponent<TextFader>();
    }

    private void RisingEdge()
    {
        GlobalState.instance.LevelTimer.Pause();
        GlobalState.instance.LevelTimer.Set(timeValue);
        _sttFader.FadeTo(centerShadingWhenOnTile, 0.5f);
        _cttFader.FadeTo(cornerShadingWhenOnTile, 0.5f);
    }

    private void FallingEdge()
    {
        GlobalState.instance.LevelTimer.Start();
        _sttFader.FadeTo(centerShadingWhenOffTile, 2f);
        _cttFader.FadeTo(cornerShadingWhenOffTile, 0.5f);
        Destroy(gameObject);
    }

    private void Update()
    {
        var playerPos = Utilities.PosToTilemapPosition(player.transform.position, 1);
        var isOn = playerPos == _tilePos;
        switch (isOn)
        {
            case true when !_wasOn:
                RisingEdge();
                break;
            case false when _wasOn:
                FallingEdge();
                break;
        }
        _wasOn = isOn;
    }
}