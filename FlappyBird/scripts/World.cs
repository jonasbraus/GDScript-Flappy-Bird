using Godot;
using System;
using Object = Godot.Object;

public class World : Node2D
{
	//-260 240
	private Sprite spriteBackground;
	private PackedScene prefabObstacle = GD.Load<PackedScene>("res://Obstacle.tscn");
	private Random random = new Random();

	public override void _Ready()
	{
		spriteBackground = GetNode<Sprite>("Background");
	}

	private void _on_Timer_timeout()
	{
		Area2D instance = prefabObstacle.Instance() as Area2D;
		instance.Position = new Vector2(instance.Position.x, random.Next(-260, 140));
		spriteBackground.AddChild(instance);
	}
}
