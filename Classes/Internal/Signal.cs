namespace ConsoleRPG.Classes.Internal;

public class Signal<TParam>
{
    private readonly List<Connection<TParam>> _connections;

    public Signal()
    {
        _connections = [];
    }


    public Connection<TParam> Connect(Func<TParam, Task> func)
    {
        var con = new Connection<TParam>(this, func);
        _connections.Add(con);
        return con;
    }

    public void RemoveConnection(Connection<TParam> connection)
    {
        _connections.Remove(connection);
    }

    public Task Fire(TParam param)
    {
        var tasks = _connections.Select(connection => connection.Function(param)).ToList();
        return Task.WhenAll(tasks);
    }
}