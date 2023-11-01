using System.Threading.Tasks;
using Godot;
using Scott.Cab.Initialization;

[Initializable]
public partial class B : DemoNode
{
	[Export] private A a;

    protected override int InitialWaitTimeInMilliSecs => 0;

    // protected virtual partial async Task OnInitialize()
	// {
	// 	await Task.Delay(WaitTime);	

	// 	GD.Print($"{Name} Initialized");
	// 	TintMesh();
	// }
}
