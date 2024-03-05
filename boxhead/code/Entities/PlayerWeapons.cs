using System.Threading.Tasks;
using Sandbox;

public sealed class PlayerWeapons : Component
{
	[Property] public Weapon CurrentWeapon
	{
		get;
		set;
	}
	
	protected override void OnStart()
	{
		_ = StartShooting();
	}
	
	private async Task StartShooting()
	{
		while ( true )
		{
			await Task.DelaySeconds( 1 );
			Shoot();
		}
	}

	private void Shoot()
	{
		CurrentWeapon.Shoot();
	}
	
}
