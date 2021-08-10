using Godot;
using System;

public class Player : RigidBody2D
{
	private const float jumpForce = -225f;
	private bool alive = true;
	private int score = 0;
	private Label labelScore;
	private ulong timeDied = 0;
	private const int respawnTime = 3;
	private Sprite spriteGameOver;

	public override void _Ready()
	{
		labelScore = GetNode<Label>("../Overlay/Score");
		spriteGameOver = GetNode<Sprite>("../GameOver");
	}

	public override void _PhysicsProcess(float delta)
	{
		if (Input.IsActionJustPressed("Click") && alive)
		{
			LinearVelocity = new Vector2(0, jumpForce);
		}

		if (!alive && OS.GetUnixTime() - timeDied > respawnTime)
		{
			GetTree().ChangeScene("res://Menu.tscn");
		}
	}

	public void die()
	{
		if(alive)
		{
			alive = false;
			GravityScale = 0;
			timeDied = OS.GetUnixTime();
			spriteGameOver.Visible = true;
		}
	}

	public void score_increase()
	{
		if(alive)
		{
			score++;
			labelScore.Text = score.ToString();
		}
	}
}
