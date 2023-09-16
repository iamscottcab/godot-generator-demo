using System.Threading.Tasks;

public class ExampleDependency : ICustomInitializable
{
    public Task Initialize()
    {
        return Task.CompletedTask;
    }
}
