#pragma warning disable CS0649

using System.Threading.Tasks;
using Godot;

public partial class NodeWithComposition : Node, ICustomInitializable
{
    private ICustomInitializable _init;
    private BasicInitializableClass _basicClass1;
    private BasicInitializableClass _basicClass2;

    // Special Godot lifetime hook
    public override void _Ready()
	{
        _init = new Initializer(Initialize(), _basicClass1, _basicClass2);  
	}

    public async Task Initialize()
    {
        // Using the dependencies down here..
        await _init.Initialize();
    }
}