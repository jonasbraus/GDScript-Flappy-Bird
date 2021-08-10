using Godot;
using System;

public class Ground : Area2D
{
	private void _on_Ground_player_entered(object body)
	{
		if (body is Player)
		{
			Player player = body as Player;
			player.die();
		}
	}
}
