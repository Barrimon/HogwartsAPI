namespace HogwartsCore.Services
{
    public interface IAppLogger<T>
    {
        void LogError(string message, params object[] args);
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
    }
}