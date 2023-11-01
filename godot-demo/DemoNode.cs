using Godot;

public abstract partial class DemoNode : Node
{
	[Export] protected Color tintColor;

	protected abstract int InitialWaitTimeInMilliSecs { get; }
	protected int WaitTime => InitialWaitTimeInMilliSecs + ((int)(GD.Randf() * 1000));

	private StandardMaterial3D _material; 

	public override void _Ready()
	{
		var label = GetChild<Label3D>(1);
		label.Text = Name;

		_material = new StandardMaterial3D();

		var mesh = GetNode<MeshInstance3D>("./Box");
		mesh.MaterialOverride = _material;
	}

	protected void TintMesh()
	{
		_material.AlbedoColor = tintColor;
	}
}
