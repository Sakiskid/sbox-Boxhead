namespace Sandbox.Entities.Weapons
{
	public class Pistol : Weapon
	{
		public override GameObject BulletExitPoint { get; set; }
		public override GameObject bulletPrefab { get; set; }

		public override void Shoot()
		{
			var bulletClone = bulletPrefab.Clone( BulletExitPoint.Transform.Position );
		}
	}
}
