using Godot;
using Scott.Cab.Initialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public partial class NodeListener : Node
{
	private readonly List<Node> _nodes = new();

	public override async void _Ready() => await InitializeAll();

	public void OnNodeAdded(Node node)
	{
		Log.Append($"Node added {node.Name}.");
		_nodes.Add(node);
	}

	private async Task InitializeAll()
	{
		var initializables = _nodes.Where(x => x is IInitializable).Select(x => ((IInitializable)x).Initialize());

		if (initializables.Any())
		{
			Log.Append($"{System.Environment.NewLine}Initializing all the nodes.{System.Environment.NewLine}");
		}

		await Task.WhenAll(initializables);
	}
}
