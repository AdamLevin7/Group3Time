public interface ICappableTimer : ITimer
{
    void SetMaximum(float maximumTime);
    double GetMaximum();
}