using System.Threading.Tasks;
using Scott.Cab.Initialization;

[Initializable]
public partial class A : DemoNode
{
    protected override int InitialWaitTimeInMilliSecs => 1250;

    // protected virtual partial async Task OnInitialize()
	// {		
	// 	await Task.Delay(WaitTime);
		
	// 	GD.Print($"{Name} Initialized");
	// 	TintMesh();
	// }
}
