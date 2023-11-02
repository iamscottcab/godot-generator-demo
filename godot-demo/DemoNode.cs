using Godot;

public abstract partial class DemoNode : Node
{
	private readonly Color initializingColor = new(1, 0, 0);
	[Export] private Color tintColor;

	protected int WaitTime => 2000 + ((int)(GD.Randf() * 1000));

	private StandardMaterial3D _material;

	public override void _Ready()
	{
		_material = new StandardMaterial3D();

		var mesh = GetChild<MeshInstance3D>(0);
		mesh.MaterialOverride = _material;

		var label = GetChild<Label3D>(1);
		label.Text = Name;
	}

	protected void SetInitializing() => _material.AlbedoColor = initializingColor;

	protected void SetInitialized()
	{
		_material.AlbedoColor = tintColor;
		Log.Append($"Initialized {Name}.");
	}
}
