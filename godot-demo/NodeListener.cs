using Godot;
using Scott.Cab.Initialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public partial class NodeListener : Node
{
	private List<Node> _nodes = new();

	public override async void _Ready()	{
		await Task.Delay(1000);
		await InitializeAll();
	}

	public void OnNodeAdded(Node node) {
		GD.Print($"node added {node.Name}.");
		_nodes.Add(node);
	}

	private async Task InitializeAll() {
		
		var initializables = _nodes.Where(x => x is IInitializable).Select(x => ((IInitializable)x).Initialize());

		if (initializables.Count() > 0) {
			GD.Print($"Initializing all the nodes.");
		}

		await Task.WhenAll(initializables);
	}
}
