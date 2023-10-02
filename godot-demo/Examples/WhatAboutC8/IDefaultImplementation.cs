using System.Threading;
using System.Threading.Tasks;

public interface IDefaultImplementation
{
    protected bool Initialized { get; set; }
    protected SemaphoreSlim Semaphore { get; set; }

    protected abstract Task OnInitialize();
    protected abstract Task InitializeDependencies();

    public sealed async Task Initialize()
    {
        Semaphore ??= new (1);
        await Semaphore.WaitAsync();

        if (Initialized)
        {
            Semaphore.Release();
            return;
        }

        try
        {
            await InitializeDependencies();
            await OnInitialize();
            Initialized = true;
        }
        finally
        {
            Semaphore.Release();
        }
    }
}