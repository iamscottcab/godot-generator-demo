using System.Threading.Tasks;
using Godot;

public partial class SomeInitializable : Node
{
    public Task Initialize()
    {
        return Task.CompletedTask;
    }
}
