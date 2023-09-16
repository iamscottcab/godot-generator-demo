using System.Threading.Tasks;
using Godot;
// using Scott.Cab.Initialization;

// [Initializable]
public partial class B : Node
{
	[Export]
	private A a;

	// protected virtual partial Task OnInitialize() {
	// 	GD.Print($"{nameof(B)} Initialized");
	// 	return Task.CompletedTask;
	// }
}
