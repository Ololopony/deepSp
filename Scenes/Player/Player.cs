using Godot;
using System;

public class Player : Area2D
{
    [Export]
    private int speed = 400;
    private Vector2 velocity;

    public override void _Process(float delta)
    {
        velocity = Vector2.Zero;

        if (Input.IsActionPressed("move_right"))
        {
            velocity.x += 1;
        }

        if (Input.IsActionPressed("move_left"))
        {
            velocity.x -= 1;
        }

        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * speed;
        }

        Position += velocity * (float)delta;
        Position = new Vector2(Position.x, Position.y);
    }
}
