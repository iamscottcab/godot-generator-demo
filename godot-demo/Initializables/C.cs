using System.Threading.Tasks;
using Godot;
using Scott.Cab.Initialization;

// [Initializable]
public partial class C : DemoNode
{
	[Export] private A a;

    // protected virtual partial async Task OnInitialize()
	// {		
	// 	await SetInitializing();
	// 	await Task.Delay(WaitTime);
	// 	await SetInitialized();
	// }
}
