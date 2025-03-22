using Godot;
using System;

public class Bullet : RigidBody2D
{
    private void OnBulletBodyEntered(Node body)
    {
        QueueFree();
    }

    private void OnVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }
}