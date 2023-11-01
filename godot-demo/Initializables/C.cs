using System.Threading.Tasks;
using Scott.Cab.Initialization;

[Initializable]
public partial class C : DemoNode
{
    protected override int InitialWaitTimeInMilliSecs => 0;

    // protected virtual partial async Task OnInitialize()
	// {
	// 	await Task.Delay(WaitTime);	
		
	// 	GD.Print($"{Name} Initialized");
	// 	TintMesh();
	// }
}
