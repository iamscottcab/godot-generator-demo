#pragma warning disable CS0649

using System.Threading.Tasks;
using Godot;

public partial class NodeWithComposition : Node, ICustomInitializable
{
    private Initializer _init;
    private BasicInitializableClass _basicClass1;
    private BasicInitializableClass _basicClass2;

    // Special Godot lifetime hook
    public override void _Ready()
	{
        _init = new Initializer(InitializeInternal(), _basicClass1, _basicClass2);     
	}

    public async Task Initialize()
    {
        await _init.Initialize();
    }

    private Task InitializeInternal() {
        // Using the dependencies down here..
        return Task.CompletedTask;
    }
}