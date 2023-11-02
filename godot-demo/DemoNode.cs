using System.Threading.Tasks;
using Godot;

public abstract partial class DemoNode : Node
{
	[Export] private Color tintColor;

	protected int WaitTime => 2000 - (_animationTimeInMilliSecs * 2);
	
	private readonly Color _initializingColor = new(1, 0, 0);
	private readonly int _animationTimeInMilliSecs = 125;

	private MeshInstance3D _mesh;
	private StandardMaterial3D _material;
	private Vector3 _from;
	private Vector3 _to;
	private float _elapsedTime;

	public override void _Ready()
	{
		_material = new StandardMaterial3D();

		_mesh = GetChild<MeshInstance3D>(0);
		_mesh.MaterialOverride = _material;

		_from = _to = _mesh.Transform.Basis.Scale;

		var label = GetChild<Label3D>(1);
		label.Text = Name;
	}

    public override void _Process(double delta)
    {
		if (_from == _to) return;

		var percent = Mathf.Clamp(_elapsedTime / (_animationTimeInMilliSecs / 1000f), 0, 1);

		var scale = _from + ((_to - _from) * percent);
		_mesh.Transform = Transform3D.Identity.Scaled(scale);

		_elapsedTime += (float)delta;

		if (percent != 1) return;
		
		_from = _to;
		_elapsedTime = 0;

		if (_to != Vector3.One) return;
		
		_material.AlbedoColor = tintColor;
		Log.Append($"Initialized {Name}.");
    }

    protected Task SetInitializing()
	{
		_material.AlbedoColor = _initializingColor;
		_to = Vector3.One * 0.75f;
		return Task.Delay(_animationTimeInMilliSecs);
	}

	protected Task SetInitialized()
	{
		_to = Vector3.One;
		return Task.Delay(_animationTimeInMilliSecs);
	}
}
