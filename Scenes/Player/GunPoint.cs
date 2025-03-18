using Godot;
using System;

public class GunPoint : Node2D
{
    [Export]
    private int speed = 800;

    private PackedScene bulletScene = GD.Load<PackedScene>("res://Scenes/Player/Bullet.tscn");

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("fire"))
        {
            RigidBody2D bullet = bulletScene.Instance<RigidBody2D>();
            bullet.Position = GlobalPosition;
            bullet.Rotation = Rotation;
            bullet.ApplyImpulse(new Vector2(), new Vector2(speed, 0).Rotated(Rotation - (Mathf.Pi / 2)));
            GetTree().Root.AddChild(bullet);
        }
    }
}
