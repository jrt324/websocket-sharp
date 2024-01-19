using System;
using System.Threading.Tasks;

namespace WebSocketSharp;

public static class Slim
{
    public static Task AsyncInvoke<T>(this Func<T> func, Action<Task<T>> callback, object o)
    {
        var task = Task.Run(() => func());
        var s= task.ContinueWith(callback);
        return task;
    }
    
    public static Task AsyncInvoke<T>(this AsyncCallback func, Action<IAsyncResult> callback, object o)
    {
        var task = Task.Run(() => func((IAsyncResult)o));
        var s= task.ContinueWith(callback);
        return task;
    }

 
}

