using Godot;

public abstract partial class DemoNode : Node
{
	private readonly Color initializingColor = new(1, 0, 0);
	private readonly int SecondInMilliSecond = 1000;
	[Export] private Color tintColor;

	protected virtual int InitialWaitTimeInMilliSecs => 0;
	protected int WaitTime => InitialWaitTimeInMilliSecs + SecondInMilliSecond + ((int)(GD.Randf() * 1000));

	private StandardMaterial3D _material;

	public override void _Ready()
	{
		var label = GetChild<Label3D>(1);
		label.Text = Name;

		_material = new StandardMaterial3D();

		var mesh = GetNode<MeshInstance3D>("./Box");
		mesh.MaterialOverride = _material;
	}

	protected void SetInitializing() => _material.AlbedoColor = initializingColor;

	protected void SetInitialized()
	{
		_material.AlbedoColor = tintColor;
		Log.Append($"Initialized {Name}.");
	}
}
