using Godot;
using System;
using System.Runtime;

public class Rocket : Node2D
{
    public int Damage {get; set;}
    public float MaxSpeed {get; set;}
    public Node2D Target {get; set;}

    private void OnVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }

    private void OnAreaHitAreaEntered(Dummy dummy)
    {
        if (dummy.HasMethod("HandleHit"))
        {
            dummy.Call("HandleHit", Damage);
        }
        QueueFree();
    }

    private void OnEnemyDetectionAreaAreaEntered(Dummy dummy)
    {
        if (Target != null)
        {
            return;
        }
        if (dummy == null)
        {
            return;
        }
        
        Target = dummy;
    }

    public override void _Process(float delta) 
    {
        if (Target is null)
        {
            Position += MaxSpeed * Vector2.Right.Rotated(Rotation) * delta;
        }
        else
        {
            LookAt(Target.GlobalPosition);
            Position = Position.MoveToward(Target.GlobalPosition, MaxSpeed * delta);
        }
    }
}
