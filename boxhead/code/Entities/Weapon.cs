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

	/// <summary>
	/// The name that is displayed to the player
	/// </summary>
	public abstract string FriendlyName { get; }

	public abstract void Shoot();
}
