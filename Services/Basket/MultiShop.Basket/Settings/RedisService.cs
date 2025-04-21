using System.Runtime.Serialization;
using StackExchange.Redis;

namespace MultiShop.Basket.Settings;

public class RedisService
{
    private readonly string _host { get; set; }
    private readonly int _port { get; set; }
    private ConnectionMultiplexer _connectionMultiplexer;

    public RedisService(string host, int port)
    {
        _host = host;
        _port = port;
    }

    public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

    public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);
}
