using Godot;
using System;
using System.Threading.Tasks;

public class ShootingController : Node2D
{
    [Export]
    private int speed = 800;
    [Export]
    private int fireRate = 500;
    private bool canFire = true;
    private PackedScene bulletScene = GD.Load<PackedScene>("res://Scenes/Player/Bullet.tscn");
    private Node2D gun;

    public override void _Ready() 
    {
        gun = GetNode<Node2D>("../Player/GunPoint");
    }

    public override void _Process(float delta) 
    {
        if (Input.IsActionPressed("fire") && canFire)
        {
            RigidBody2D bullet = bulletScene.Instance<RigidBody2D>();
            bullet.Position = gun.GlobalPosition;
            bullet.Rotation = gun.GlobalRotation;
            bullet.ApplyImpulse(new Vector2(), new Vector2(speed, 0).Rotated(gun.GlobalRotation - (Mathf.Pi / 2)));
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
