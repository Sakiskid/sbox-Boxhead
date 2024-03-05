using Sandbox;

public abstract class Weapon : Component
{
	// properties
	public abstract GameObject BulletExitPoint
	{
		get;
		set;
	}

	public abstract GameObject bulletPrefab
	{
		get;
		set;
	}

	public abstract void Shoot();
}
