using System.Threading.Tasks;

public partial class InheritedExample
{
    protected override Task InitializeDependencies()
    {
        // Assuming we can source generate this I guess?
        Task[] tasks = new Task[]
        {
            _dep2.Initialize(),
            base.InitializeDependencies()
        };

        return Task.WhenAll(tasks);
    }
}