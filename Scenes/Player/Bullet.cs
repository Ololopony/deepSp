using Godot;
using System;

public class Bullet : RigidBody2D
{
    public int Damage {get; set;}

    private void OnBulletBodyEntered(Node body)
    {
        if (body.HasMethod("HandleHit"))
        {
            body.Call("HandleHit", Damage);
        }
        QueueFree();
    }

    private void OnVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }
}