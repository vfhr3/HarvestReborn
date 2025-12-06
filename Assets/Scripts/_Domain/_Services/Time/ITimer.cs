namespace _Domain._Services.Time
{
    public interface ITimer
    {
        bool IsRunning { get; }
        float TimeLeft { get; }
        float Progress { get; }

        void Start();
        void Stop();
        void Update(float deltaTime);
    }
}