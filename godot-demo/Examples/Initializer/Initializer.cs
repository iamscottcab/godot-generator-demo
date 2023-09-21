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
        onInitialze ??= Task.CompletedTask;
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
            await Task.WhenAll(_dependencies);
            await _onInitialize;
            _initialized = true;
        }
        finally
        {
            _semaphore.Release();
        }
    }
}