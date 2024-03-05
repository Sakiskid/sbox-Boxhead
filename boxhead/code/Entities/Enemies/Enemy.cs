using Sandbox;
using Sandbox.Diagnostics;

public abstract class Enemy : Component, IDamageable
{
	internal Logger Log = new Logger( "Enemy: " );
	[Property] public float Health { get; set; }
	
	public abstract void OnCollisionStart( Collision other );
	public abstract void OnCollisionUpdate( Collision other );
	public abstract void OnCollisionStop( CollisionStop other );
	
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
