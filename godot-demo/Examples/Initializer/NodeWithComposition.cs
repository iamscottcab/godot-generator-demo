#pragma warning disable CS0649

using System.Threading.Tasks;
using Godot;

public partial class NodeWithComposition : Node
{
    private Initializer _init;
    private BasicInitializableClass _basicClass1;
    private BasicInitializableClass _basicClass2;

    // Special Godot lifetime hook
    public override async void _Ready()
	{
        _init = new Initializer(Initialize(), _basicClass1, _basicClass2);  
        await _init.Initialize();   
	}

    private Task Initialize()
    {
        // Using the dependencies down here..
        return Task.CompletedTask;
    }
}