using Godot;
using System;

public class Bullet : RigidBody2D
{
    private void OnBulletBodyEntered(Node body)
    {
        if (body.HasMethod("HandleHit"))
        {
            body.Call("HandleHit");
        }
        QueueFree();
    }

    private void OnVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }
}