using System;
using System.Diagnostics;
using Sandbox;
using Sandbox.Diagnostics;

public sealed class PlayerPhysics : Component
{
	[Property] public float friction;
	[Property] public float moveSpeed;

	[Property] private Vector3 inputDir;

	private Rigidbody rb;
	private CharacterController charCont;

	protected override void OnStart()
	{
		charCont = this.GameObject.Components.Get<CharacterController>();
		rb = GameObject.Components.Get<Rigidbody>();
	}

	protected override void OnFixedUpdate()
	{
		base.OnFixedUpdate();

		Move();
		FaceDirection();
	}

	private void Move()
	{
		if ( IsProxy ) return;

		rb.Velocity = 0;
		rb.AngularVelocity = Vector3.Zero;
		Vector3 finalVelocity = Vector3.Zero;

		// Input Direction
		inputDir = Input.AnalogMove;
		inputDir.z = 0;

		// Add speed to direction
		finalVelocity += inputDir * moveSpeed;
		
		// Apply gravity
		if ( charCont.IsOnGround )
			charCont.ApplyFriction( 5f );
		else 
			finalVelocity += Scene.PhysicsWorld.Gravity;

		// Apply velocity and move
		charCont.Velocity = finalVelocity;
		charCont.Move();
	}

	private void FaceDirection()
	{
		if ( IsProxy ) return;
		
		if ( inputDir == Vector3.Zero ) return;
		GameObject.Transform.Rotation = Rotation.LookAt(inputDir, Vector3.Up);
	}
}
