using System;
using System.Diagnostics;
using Sandbox;

public sealed class Bullet : Component, Component.ICollisionListener
{
	[Property] public float Speed { get; set; }
	[Property] public float Damage { get; set; }

	protected override void OnUpdate()
	{
		Transform.Position += Transform.Rotation.Forward * Speed * Time.Delta;
	}
	
	public void OnCollisionStart( Collision other )
	{
		var enemy = other.Other.GameObject.Components.Get<Enemy>();
		if ( enemy != null )
		{
			enemy.TakeDamage( Damage );
		}
	}

	public void OnCollisionUpdate( Collision other )
	{
		return;
	}

	public void OnCollisionStop( CollisionStop other )
	{
		return;
	}
}
