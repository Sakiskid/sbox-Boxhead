using Sandbox;
using Sandbox.Diagnostics;
using Sandbox.Entities;

public abstract class Enemy : Component, IDamageable
{
	internal Logger Log = new Logger( "Enemy: " );
	
	[Property] public float Health { get; set; }
	[Property] internal NavMeshAgent Agent { get; set; }
	
	public abstract void OnCollisionStart( Collision other );
	public abstract void OnCollisionUpdate( Collision other );
	public abstract void OnCollisionStop( CollisionStop other );

	protected override void OnUpdate()
	{
		Agent.MoveTo(PlayerTracker.Players[0].Transform.Position);
	}

	public void TakeDamage( float amt )
	{
		Health = Health - amt;
		if ( Health <= 0 ) Die();
	}
	
	internal virtual void Die()
	{
		Log.Info($"{GameObject.Name} dying!");
		GameObject.Destroy();
	}
}
