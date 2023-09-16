using Godot;

public partial class Z : A
{
	[Export]
	private C c;

	protected override string NodeName => "Z";
}
