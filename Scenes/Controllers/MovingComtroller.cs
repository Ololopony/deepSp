using Godot;
using System;

public class MovingComtroller : Node2D
{
    [Export]
    private int speed = 400;
    PathFollow2D path;

    public override void _Ready() 
    {
        path = GetNode<PathFollow2D>("%PathFollowForPlayer");
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("move_right"))
        {
            path.Offset += speed;
        }

        if (Input.IsActionPressed("move_left"))
        {
            path.Offset -= speed;
        }
    }
}
