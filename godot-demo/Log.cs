using Godot;

public partial class Log : Node
{
	[Export] private Label label;

	private static Log _instance;

	public override void _EnterTree()
	{
		_instance = this;
	}

	public static void Append(string text)
	{
		if (_instance == null) return;

		var originalText = _instance.label.Text;
		var needsNewLine = !string.IsNullOrEmpty(originalText);
		_instance.label.Text = $"{originalText}{(needsNewLine ? System.Environment.NewLine : "")}{text}";
	}
}
