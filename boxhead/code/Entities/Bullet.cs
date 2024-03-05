using System;
using System.Diagnostics;
using Sandbox;
using Sandbox.Diagnostics;
using Sandbox.Entities.Enemies;

public sealed class Bullet : Component, Component.ICollisionListener
{
	private Logger Log = new Logger("Bullet Logger");
	
	[Property] public float Speed { get; set; }
	[Property] public float Damage { get; set; }

	protected override void OnUpdate()
	{
		Transform.Position += Transform.Rotation.Forward * Speed * Time.Delta;
	}
	
	public void OnCollisionStart( Collision other )
	{
		Log.Info("Collision");
		var enemy = other.Other.GameObject.Components.Get<Enemy>();
		var zombo = other.Other.GameObject.Components.Get<Zombo>();
		Log.Info("zombo or enemy? " + (enemy == null) + (zombo == null) );
		if ( enemy != null )
		{
			Log.Info("Giving enemy damage: " + Damage);
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
