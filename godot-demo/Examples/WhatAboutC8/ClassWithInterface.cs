using System.Threading;
using System.Threading.Tasks;
using Godot;

public partial class ClassWithInterface : Node, IDefaultImplementation
{
    // Source generated?
    bool IDefaultImplementation.Initialized { get; set; }
    SemaphoreSlim IDefaultImplementation.Semaphore { get; set; }

    Task IDefaultImplementation.InitializeDependencies()
    {
        throw new System.NotImplementedException();
    }

    // Developer implementation
    Task IDefaultImplementation.OnInitialize()
    {
        return Task.CompletedTask;
    }

    public override async void _Ready()
    {
        await (this as IDefaultImplementation).Initialize();
    }
}