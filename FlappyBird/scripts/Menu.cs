using Godot;
using System;

public class Menu : Control
{
	public override void _Process(float delta)
	{
		if (Input.IsActionJustPressed("Click"))
		{
			GetTree().ChangeScene("res://World.tscn");
		}
	}
}
