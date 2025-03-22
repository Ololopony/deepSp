using Godot;
using System;

public class Dummy : Area2D
{
	private int health = 100;

	public void HandleHit(int damage)
	{
		GD.Print("Was hit");
		health -= damage;
		if (health > 0)
		{
			GD.Print(health);
		}
		else
		{
			GD.Print("Killed");
			QueueFree();
		}
	}
}
