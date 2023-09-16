using System.Threading.Tasks;

[CustomInitializable]
public partial class Example
{
    private readonly ExampleDependency _dep = new();

    protected virtual partial Task OnInitialize() {
        // Do some fancy initialization here or something...
        return Task.CompletedTask;
    }
}