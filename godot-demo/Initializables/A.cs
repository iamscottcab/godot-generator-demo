using System.Threading.Tasks;
using Scott.Cab.Initialization;

// [Initializable]
public partial class A : DemoNode
{
    protected override int InitialWaitTimeInMilliSecs => 1250;

    // protected virtual partial async Task OnInitialize()
	// {		
	// 	SetInitializing();
	// 	await Task.Delay(WaitTime);
	// 	SetInitialized();
	// }
}
