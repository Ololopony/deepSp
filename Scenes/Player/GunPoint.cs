using Godot;
using System;
using System.Threading.Tasks;

public class GunPoint : Node2D
{
    [Export]
    private int speed = 800;
    [Export]
    private int fireRate = 500;
    private bool canFire = true;
    private PackedScene bulletScene = GD.Load<PackedScene>("res://Scenes/Player/Bullet.tscn");

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("fire") && canFire)
        {
            RigidBody2D bullet = bulletScene.Instance<RigidBody2D>();
            bullet.Position = GlobalPosition;
            bullet.Rotation = Rotation;
            bullet.ApplyImpulse(new Vector2(), new Vector2(speed, 0).Rotated(Rotation - (Mathf.Pi / 2)));
            GetTree().Root.AddChild(bullet);
            Wait();
        }
    }

    private async void Wait()
    {
        canFire = false;
        await Task.Delay(fireRate);
        canFire = true;
    }
}
