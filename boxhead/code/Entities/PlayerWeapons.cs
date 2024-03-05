using System.Threading.Tasks;
using Sandbox;

public sealed class PlayerWeapons : Component
{
	[Property] public Weapon CurrentWeapon
	{
		get;
		set;
	}

	protected override void OnUpdate()
	{
		if ( IsProxy ) return;
		base.OnUpdate();
		if ( Input.Down( "attack1" ) )
		{
			Shoot();
		}
	}

	// Keeping this for async example
	// private async Task StartShooting()
	// {
	// 	while ( true )
	// 	{
	// 		await Task.DelaySeconds( 1 );
	// 		Shoot();
	// 	}
	// }

	private void Shoot()
	{
		CurrentWeapon.Shoot();
	}
	
}
