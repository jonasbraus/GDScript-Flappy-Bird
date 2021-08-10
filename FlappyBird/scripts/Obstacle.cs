using Godot;
using System;

public class Obstacle : Area2D
{
	private const float moveSpeed = 145f;
	

	private void _on_Pipe_player_entered(object body)
	{
		if (body is Player)
		{
			Player player = body as Player;
			player.die();
		}
	}
	
	private void _on_Obstacle_player_exited(object body)
	{
		if (body is Player)
		{
			Player player = body as Player;
			player.score_increase();
		}
	}

	public override void _PhysicsProcess(float delta)
	{
		Translate(new Vector2(-moveSpeed * delta, 0));

		if (Position.x < -200)
		{
			QueueFree();
		}
	}
}
