using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Sandbox;
using Sandbox.Diagnostics;
using Sandbox.Entities.Enemies;

public sealed class Bullet : Component, Component.ICollisionListener
{
	private Logger Log = new Logger("Bullet Logger");
	
	[Property] public float Speed { get; set; }
	[Property] public float Damage { get; set; }

	protected override void OnStart()
	{
		base.OnStart();
		_ = StartExpireTimer();
	}

	protected override void OnUpdate()
	{
		Transform.Position += Transform.Rotation.Forward * Speed * Time.Delta;
	}
	
	public void OnCollisionStart( Collision other )
	{
		// var enemy = other.Other.GameObject.Components.Get<Enemy>();
		var target = other.Other.GameObject.Components.Get<Sandbox.IDamageable>();
		
		// If it's a damageable:
		if ( target != null )
		{
			Log.Info("Giving enemy damage: " + Damage);
			target.TakeDamage( Damage );
		}
		
		// destroy the bullet
		GameObject.Destroy();
	}

	public void OnCollisionUpdate( Collision other )
	{
		return;
	}

	public void OnCollisionStop( CollisionStop other )
	{
		return;
	}

	private async Task StartExpireTimer()
	{
		await Task.DelaySeconds( 5 );
		GameObject.Destroy();
	}
}
