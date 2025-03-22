using Godot;
using System;
using System.Threading.Tasks;

public class ShootingController : Node2D
{
    [Export]
    private int speed = 800;
    [Export]
    private int fireRateBullets = 500;
    [Export]
    private int fireRateRockets = 1000;
    [Export]
    private int bulletDamage = 1;
    [Export]
    private int rocketDamage = 1;
    [Export]
    private float rocketSpeed = 200;
    private bool canFireBullets = true;
    private bool canFireRockets = true;
    private bool fireType = true;
    private PackedScene bulletScene = GD.Load<PackedScene>("res://Scenes/Player/Bullet.tscn");
    private PackedScene rocketScene = GD.Load<PackedScene>("res://Scenes/Player/Rocket.tscn");
    private Node2D gun;

    public override void _Ready() 
    {
        gun = GetNode<Node2D>("%GunPoint");
    }

    public override void _Process(float delta) 
    {
        if (Input.IsActionPressed("fire"))
        {
            if (fireType && canFireBullets)
            {
                Bullet bullet = bulletScene.Instance<Bullet>();
                bullet.Damage = bulletDamage;
                bullet.Position = gun.GlobalPosition;
                bullet.Rotation = gun.GlobalRotation;
                bullet.ApplyImpulse(new Vector2(), new Vector2(speed, 0).Rotated(gun.GlobalRotation - (Mathf.Pi / 2)));
                // Просто передаем испульс снаряду, дельше физика движка сама все считает
                GetTree().Root.AddChild(bullet);
                WaitBullets();
            }
            else if (!fireType && canFireRockets)
            {
                Rocket rocket = rocketScene.Instance<Rocket>();
                rocket.Damage = rocketDamage;
                rocket.Position = gun.GlobalPosition;
                rocket.Rotation = gun.GlobalRotation - (Mathf.Pi / 2);
                rocket.MaxSpeed = rocketSpeed;
                GetTree().Root.AddChild(rocket);
                WaitRockets();
            }
        }
        if (Input.IsActionPressed("choose_bullets"))
        {
            fireType = true;
        }
        if (Input.IsActionPressed("choose_rockets"))
        {
            fireType = false;
        }
    }

    private async void WaitBullets()
    {
        canFireBullets = false;
        await Task.Delay(fireRateBullets);
        canFireBullets = true;
    }

    private async void WaitRockets()
    {
        canFireRockets = false;
        await Task.Delay(fireRateRockets);
        canFireRockets = true;
    }
}
