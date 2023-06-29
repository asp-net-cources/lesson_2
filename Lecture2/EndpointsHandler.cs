namespace Lecture2;

public class EndpointsHandler
{
    /// <summary>
    /// Эндпоинт HelloWorldEndpoint, не сопоставленный с запросом
    /// </summary>
    /// <param name="context">Контект запроса. Добавляйте этот аргумент в методы эндпоинтов вне контроллера, но пока игнорируйте.</param>
    /// <returns>Hello world!</returns>
    public static string HelloWorldEndpoint(HttpContext context) {
        return "Hello world!";
    }

    /// <summary>
    /// Эндпоинт SquareEndpoint, не сопоставленный с запросом
    /// Эндпоинт принимает обязательный аргумент value
    /// </summary>
    /// <param name="context">Контект запроса. Добавляйте этот аргумент в методы эндпоинтов вне контроллера, но пока игнорируйте.</param>
    /// <param name="value">Обязательный аргумент</param>
    /// <returns>Возведённое в квадрат число</returns>
    public static int SquareEndpoint(HttpContext context, int value) {
        return value * value;
    }
}
