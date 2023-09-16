using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class Initializer : ICustomInitializable
{
    private bool _initialized;
    private readonly SemaphoreSlim _semaphore = new(1);
    private readonly IEnumerable<Task> _dependencies;
    private readonly Task _onInitialize;

    public Initializer(Task onInitialze, params ICustomInitializable[] dependencies) 
    {
        _onInitialize = onInitialze;

        dependencies ??= Array.Empty<ICustomInitializable>();
        _dependencies = dependencies.Select(x => x.Initialize());
    }

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
            await _onInitialize;
            _initialized = true;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    private Task InitializeDependencies() {
        return Task.WhenAll(_dependencies);
    }
}