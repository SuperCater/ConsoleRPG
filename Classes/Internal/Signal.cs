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

    public Connection<TParam> Once(Func<TParam> func)
    {
        Connection<TParam> con;
        con = new Connection<TParam>(this, param =>
        {
            func(param);
            RemoveConnection(con);
            return Task.CompletedTask;
        });
        return con;
    }
    
    /// <summary>
    /// This method will block the current thread until the signal is fired.
    /// </summary>
    /// <returns>The param that was passed in .Fire()</returns>
    public TParam Wait()
    {
        var tcs = new TaskCompletionSource<TParam>();
        Connect(param =>
        {
            tcs.SetResult(param);
            return Task.CompletedTask;
        });
        return tcs.Task.Result;
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