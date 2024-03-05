using System.Threading.Tasks;
using Sandbox;
using Sandbox.Diagnostics;
using Sandbox.Entities;

public abstract class Enemy : Component, IDamageable
{
	internal Logger Log = new Logger( "Enemy: " );
	
	[Property] public float Health { get; set; }
	[Property] internal NavMeshAgent Agent { get; set; }
	
	internal float intervalBetweenCheckingTargetPosition;
	internal Vector2 checkTargetPositionRange = new Vector2( 0.5f, 2f );
	
	// Collision Methods
	public abstract void OnCollisionStart( Collision other );
	public abstract void OnCollisionUpdate( Collision other );
	public abstract void OnCollisionStop( CollisionStop other );
	
	
	protected override void OnStart()
	{
		intervalBetweenCheckingTargetPosition = Game.Random.Float( checkTargetPositionRange.x, checkTargetPositionRange.y );
		_ = CheckAndUpdateTarget();
	}

	internal async Task CheckAndUpdateTarget()
	{
		while ( true )
		{
			Agent.MoveTo(PlayerTracker.Players[0].Transform.Position);
			await Task.DelaySeconds( intervalBetweenCheckingTargetPosition );
		}
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
