using System.Threading.Tasks;

public partial class MyCustomNode : InitializableNode
{
    private SomeInitializable _someInitializable;

    protected override async Task InitializeDependencies()
    {
        await _someInitializable.Initialize();
    }

    protected override Task OnInitialize()
    {
        return Task.CompletedTask;
    }
}
