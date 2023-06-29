using Lecture2;

// Создаем билдер (https://refactoring.guru/ru/design-patterns/builder) с входными аргументами args
var builder = WebApplication.CreateBuilder(args);

// Регистрируем контроллеры
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Регистриуем сваггер
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Создаем WebApplication
var app = builder.Build();

// Указываем использование сваггера для генерации документации в yaml и json формате
app.UseSwagger();

// Смысл: Проверяем является ли наше окружение окружением разработки
// Реализация: Проверяем переменную среды ASPNETCORE_ENVIRONMENT на равенство "Development"
// Настройка: Переменные среды мы задаём в файле .\Properties\launchSettings.json в каждом профиле
if (app.Environment.IsDevelopment()) {
    // Указываем использование UI сваггера
    app.UseSwaggerUI();
}

// Смысл: Проверяем включено ли использование эндпоинтов вне контроллеров
// Реализация: Достаём значение из конфигурации WebApplication и приводим его к типу boolean.
// Настройка: конфигурация задаётся из входных аргументов, переменных среды, файла appsettings.json (appsettings.Development.json). Значение для EnableEndpoints мы задали в appsettings.json (appsettings.Development.json).
if (app.Configuration.GetValue<bool>("EnableEndpoints")) {
    // Задаём роутинг для запросов и эндпоинтов
    app.MapGet("helloWorld", EndpointsHandler.HelloWorldEndpoint);
    app.MapGet("square", EndpointsHandler.SquareEndpoint);
}

// Включаем роутинг для эндпоинтов контроллера
app.MapControllers();

// Запускаем наше приложение
// Оно в бесконечном цикле будет ожидать приходящие запросы до тех пор, пока мы не остановим программу
app.Run();
