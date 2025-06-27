namespace ConsoleRPG.Classes.Internal;

public class Connection<TParam>(Signal<TParam> owner, Func<TParam, Task> func)
{
    public Func<TParam, Task> Function = func;
    private Signal<TParam> Signal = owner;

    public void Disconnect()
    {
        Signal.RemoveConnection(this);
    }
}

