public interface ITimer
{
    public float GetTimeScale();
    public void SetTimeScale(float timeScale);
    
    public float GetSeconds();
    public void Set(float seconds);
    public void Add(float seconds);
    public void Pause();
    public void Start();
    public bool IsRunning();

    public void Update();
}