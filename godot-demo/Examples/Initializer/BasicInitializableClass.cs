using System.Threading.Tasks;

public class BasicInitializableClass : ICustomInitializable
{
    public Task Initialize()
    {
        return Task.CompletedTask;
    }
}