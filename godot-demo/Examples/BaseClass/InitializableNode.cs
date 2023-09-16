using System.Threading;
using System.Threading.Tasks;
using Godot;

public abstract partial class InitializableNode : Node
{
    private bool _initialized;
    private readonly SemaphoreSlim _semaphore = new(1);

    protected abstract Task OnInitialize();
    protected abstract Task InitializeDependencies();

    public async Task Initialize()
    {
        await _semaphore.WaitAsync();

        if (_initialized)
        {
            _semaphore.Release();
            return;
        }

        try
        {
            await InitializeDependencies();
            await OnInitialize();
            _initialized = true;
        }
        finally
        {
            _semaphore.Release();
        }
    }
}
