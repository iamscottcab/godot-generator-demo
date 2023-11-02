using Godot;
using Scott.Cab.Initialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public partial class NodeListener : Node
{
	private List<Node> _nodes = new();
	private bool _initializing;

    public void OnNodeAdded(Node node)
	{
		_nodes.Add(node);
	}

    public override void _Ready()
    {
		var rand = new Random();
		_nodes = _nodes.OrderBy(x => rand.Next()).ToList();

		foreach (var node in _nodes)
			Log.Append($"Added node {node.Name}.");
    }

    public override async void _Input(InputEvent inputEvent)
    {
		if (inputEvent is not InputEventKey keyEvent || keyEvent.Keycode != Key.Space) return;
		if (!keyEvent.IsPressed() || keyEvent.IsEcho()) return;	
		if (_initializing) return;

		_initializing = true;
		await InitializeAll();
    }

	private async Task InitializeAll()
	{
		var initializeTasks = _nodes.Where(x => x is IInitializable).Select(x => ((IInitializable)x).Initialize());

		if (initializeTasks.Any())
			Log.Append($"{System.Environment.NewLine}Initializing all the nodes.{System.Environment.NewLine}");

		await Task.WhenAll(initializeTasks);
	}
}
