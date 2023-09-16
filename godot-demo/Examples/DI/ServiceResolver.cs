using System.Collections.Generic;
using System.Linq;
using Godot;

public partial class ServiceResolver : Node
{
    private readonly List<object> _services = new();

    public void Bind<T>(T c) {
        _services.Add(c);
    }

    public T Resolve<T>() {
        return (T)_services.FirstOrDefault(x => x.GetType() == typeof(T));
    }
}
