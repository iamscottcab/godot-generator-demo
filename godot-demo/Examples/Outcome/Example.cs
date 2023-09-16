using System.Threading.Tasks;
using Godot;

[CustomInitializable]
public partial class Example : Node
{
    private readonly ExampleDependency _dep = new();

    protected virtual partial Task OnInitialize()
    {
        // Do some fancy initialization here or something...
        return Task.CompletedTask;
    }
}