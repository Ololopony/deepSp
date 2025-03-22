using Godot;
using System;

public class Dummy : KinematicBody2D
{
    private int health = 100;

    public void HandleHit()
    {
        GD.Print("Was hit");
        health -= 10;
        if (health > 0)
        {
            GD.Print(health);
        }
        else
        {
            GD.Print("Killed");
            QueueFree();
        }
    }
}
