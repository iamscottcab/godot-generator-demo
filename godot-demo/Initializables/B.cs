using System.Threading.Tasks;
using Godot;
using Scott.Cab.Initialization;

// [Initializable]
public partial class B : DemoNode
{
	[Export] private A a;

    // protected virtual partial async Task OnInitialize()
	// {		
	// 	SetInitializing();
	// 	await Task.Delay(WaitTime);
	// 	SetInitialized();
	// }
}
