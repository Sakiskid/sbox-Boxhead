using System.Threading.Tasks;
using Sandbox;

public sealed class PlayerWeapons : Component
{

	[Property] public GameObject PistolObject;
	[Property] public Weapon CurrentWeapon
	{
		get;
		set;
	}
	
	protected override void OnStart()
	{
		CurrentWeapon = PistolObject.Components.Get<Weapon>();
		_ = StartShooting();
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if ( IsProxy ) return;
		if ( Input.Down( "attack1" ) )
		{
			Shoot();
		}
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
