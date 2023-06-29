using Microsoft.AspNetCore.Mvc;

namespace Lecture2.Controllers;

[ApiController]
/// <summary>
/// Класс - контроллер
[Route("api/pizzaDelivery")]
/// Все запросы, имеющие приставку api/pizzaDelivery будут попадать на этот контроллер
/// </summary>
public class PizzaController
{
    /// <summary>
    /// Эндпоинт GetHelloWorld сопоставленный с запросом http://localhost:5130/api/pizzaDelivery/me/id
    /// Полный путь до этого эндпоинта складывается из пути до контроллера (http://localhost:5130/api/pizzaDelivery и внутреннего пути до эндпоинтв /me/id)
    /// </summary>
    /// <returns>Число 25</returns>
    [HttpGet("me/id")]
    public int GetMyId() {
        return 25;
    }

    /// <summary>
    /// Эндпоинт GetHelloWorld сопоставленный с запросом http://localhost:5130/api/pizzaDelivery/pizzas
    /// Эндпоинт принимает опциональный аргумент isVeganOnly.
    /// Полный путь до этого эндпоинта складывается из пути до контроллера (http://localhost:5130/api/pizzaDelivery и внутреннего пути до эндпоинтв /pizzas)
    /// </summary>
    /// <param name="isVeganOnly">Опциональный аргумент буленовского типа</param>
    /// <returns>Массив названий пицц</returns>
    [HttpGet("pizzas")]
    public string[] GetPizzas(bool isVeganOnly = false) {
        if (isVeganOnly) {
            return new string[] { "Маргарита", "Овощная" };
        }

        return new string[] { "Маргарита", "Пеперони", "Барбекю", "Овощная" };
    }
}
