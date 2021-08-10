using HogwartsCore.Services;
using Microsoft.Extensions.Logging;

namespace HogwartsInfrastructure.Logger
{
    public class AppLogger<TEntity> : IAppLogger<TEntity>
    {
        private readonly ILogger<TEntity> _logger;

        public AppLogger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TEntity>();
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }
    }
}
