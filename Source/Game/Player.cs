using System;
using System.Collections.Generic;
using FlaxEditor.Surface.Elements;
using FlaxEngine;

namespace Game;

/// <summary>
/// Player Script.
/// </summary>
public class Player : Script
{
    public RigidBody RigidBody;
    public BoxCollider BoxCollider;
    public SceneReference SceneReference;
    
    /// <inheritdoc/>
    public override void OnStart()
    {
        // Here you can add code that needs to be called when script is created, just before the first game update
    }
    
    /// <inheritdoc/>
    public override void OnEnable()
    {
        BoxCollider.TriggerEnter += OnTriggerEnter;
    }

    /// <inheritdoc/>
    public override void OnDisable()
    {
        // Here you can add code that needs to be called when script is disabled (eg. unregister from events)
    }

    /// <inheritdoc/>
    public override void OnUpdate()
    {
        // Here you can add code that needs to be called every frame
    }

    public override void OnFixedUpdate()
    {
        // Actor.Position += new Vector3(3, 0, 0);
        if (Input.Keyboard.GetKey(KeyboardKeys.A))
        {
            RigidBody.LinearVelocity = Vector3.Left * 500;
        }
        if (Input.Keyboard.GetKey(KeyboardKeys.D))
        {
            RigidBody.LinearVelocity = Vector3.Right * 500;
        }
        if (Input.Keyboard.GetKey(KeyboardKeys.W))
        {
            RigidBody.LinearVelocity = Vector3.Forward * 500;
        }
        if (Input.Keyboard.GetKey(KeyboardKeys.S))
        {
            RigidBody.LinearVelocity = Vector3.Backward * 500;
        }
    }
    
    private void OnTriggerEnter(PhysicsColliderActor other)
    {
        Debug.Log(string.Join(" ", other.Tags));
        if (other.Tag == "Finish")
        {
            Level.ChangeSceneAsync(SceneReference);
        }
        // if (other.HasTag(PlayerTag))
        // {
        //     Debug.Log("Player entered trigger");
        // }
        // else if (other.Tags.HasAny(EnemyTags))
        // {
        //     Debug.Log("Enemy entered trigger");
        // }
    }
}
