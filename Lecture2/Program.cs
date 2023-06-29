using Lecture2;

// ������� ������ (https://refactoring.guru/ru/design-patterns/builder) � �������� ����������� args
var builder = WebApplication.CreateBuilder(args);

// ������������ �����������
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// ����������� �������
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ������� WebApplication
var app = builder.Build();

// ��������� ������������� �������� ��� ��������� ������������ � yaml � json �������
app.UseSwagger();

// �����: ��������� �������� �� ���� ��������� ���������� ����������
// ����������: ��������� ���������� ����� ASPNETCORE_ENVIRONMENT �� ��������� "Development"
// ���������: ���������� ����� �� ����� � ����� .\Properties\launchSettings.json � ������ �������
if (app.Environment.IsDevelopment()) {
    // ��������� ������������� UI ��������
    app.UseSwaggerUI();
}

// �����: ��������� �������� �� ������������� ���������� ��� ������������
// ����������: ������ �������� �� ������������ WebApplication � �������� ��� � ���� boolean.
// ���������: ������������ ������� �� ������� ����������, ���������� �����, ����� appsettings.json (appsettings.Development.json). �������� ��� EnableEndpoints �� ������ � appsettings.json (appsettings.Development.json).
if (app.Configuration.GetValue<bool>("EnableEndpoints")) {
    // ����� ������� ��� �������� � ����������
    app.MapGet("helloWorld", EndpointsHandler.HelloWorldEndpoint);
    app.MapGet("square", EndpointsHandler.SquareEndpoint);
}

// �������� ������� ��� ���������� �����������
app.MapControllers();

// ��������� ���� ����������
// ��� � ����������� ����� ����� ������� ���������� ������� �� ��� ���, ���� �� �� ��������� ���������
app.Run();
