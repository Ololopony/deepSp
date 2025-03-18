using Godot;
using System;

public class Player : Area2D
{
    [Export]
    private int speed { get; set; } = 400; // How fast the player will move (pixels/sec).

    private Vector2 screenSize; // Size of the game window.

    private Vector2 velocity; // The player's movement vector.

    public override void _Ready()
    {
        screenSize = GetViewportRect().Size;
    }

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
        Position = new Vector2(
            x: Mathf.Clamp(Position.x, 0, screenSize.x),
            Position.y
        );
    }
}
