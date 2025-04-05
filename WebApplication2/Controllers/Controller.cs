using Microsoft.AspNetCore.Mvc;
using WebApplication2.Contracts; // Пространство имен для ILoggerManager

namespace WebApplication2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        // Конструктор с внедрением зависимости ILoggerManager
        public WeatherForecastController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            // Примеры логирования разных уровней
            _logger.LogInfo("Вот информационное сообщение от нашего контроллера значений.");
            _logger.LogDebug("Вот отладочное сообщение от нашего контроллера значений.");
            _logger.LogWarn("Вот сообщение предупреждения от нашего контроллера значений.");
            _logger.LogError("Вот сообщение об ошибке от нашего контроллера значений.");

            return new string[] { "value1", "value2" };
        }
    }
}