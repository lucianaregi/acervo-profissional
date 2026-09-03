namespace AcervoProfissional.Mcp;

public class Worker(ILogger<Worker> logger, IConfiguration configuration) : BackgroundService
{
    private static readonly TimeSpan DefaultInterval = TimeSpan.FromSeconds(60);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var interval = TryGetInterval(configuration, "MCP_INTERVAL_SECONDS");

        using var timer = new PeriodicTimer(interval);

        try
        {
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                if (logger.IsEnabled(LogLevel.Information))
                {
                    logger.LogInformation("MCP worker running at: {time}", DateTimeOffset.Now);
                }
            }
        }
        catch (OperationCanceledException)
        {
            // encerramento solicitado via stoppingToken — comportamento esperado
        }
    }

    private static TimeSpan TryGetInterval(IConfiguration configuration, string key)
    {
        var raw = configuration[key];
        if (int.TryParse(raw, out var seconds) && seconds > 0)
            return TimeSpan.FromSeconds(seconds);

        return DefaultInterval;
    }
}
