using System.Threading;
using System.Threading.Tasks;

public partial class Example : ICustomInitializable
{
    private bool _initialized;
    private readonly SemaphoreSlim _semaphore = new(1);
    
    protected virtual partial Task OnInitialize();
    
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

    protected virtual Task InitializeDependencies()
    {
        // I dunno I guess this is source generated?!
        return Task.WhenAll(new[] {
            _dep.Initialize(),
        });
    }
}