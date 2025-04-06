using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Client;


namespace SampleClient;


// Создаем класс для уведомления, который соответствует формату, отправляемому сервером.
public class NotificationMessage
{
    public Guid EventId { get; set; }
    public string Message { get; set; }
    // Дополните другими полями, если необходимо.
}

class Program
{
    // Асинхронный Main позволяет использовать await.
    static async Task Main(string[] args)
    {
        // Замените на ваш реальный JWT-токен.
        string yourJwtToken = "your_jwt_token_here";

        // Укажите URL вашего хаба. Его можно получить, если NotificationService.API запущен локально.
        string hubUrl = "https://localhost:7223/notificationHub";

        // Создаем подключение к хабу с указанием провайдера токена.
        var connection = new HubConnectionBuilder()
            .WithUrl(hubUrl, options =>
            {
                // Передача токена для авторизации
                options.AccessTokenProvider = () => Task.FromResult(yourJwtToken);
            })
            .Build();

        // Подписываемся на событие ReceiveNotification.
        connection.On<NotificationMessage>("ReceiveNotification", (notification) =>
        {
            Console.WriteLine("Получено уведомление:");
            Console.WriteLine($"EventId: {notification.EventId}");
            Console.WriteLine($"Message: {notification.Message}");
        });

        try
        {
            // Запуск подключения к хабу.
            await connection.StartAsync();
            Console.WriteLine("Подключение установлено.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка подключения: {ex}");
        }

        Console.WriteLine("Нажмите Enter для завершения...");
        Console.ReadLine();

        // Останавливаем подключение перед выходом.
        await connection.StopAsync();
    }
}
