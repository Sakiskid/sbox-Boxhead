namespace Sandbox.Entities.Weapons
{
	public class Pistol : Weapon
	{
		[Property] public override GameObject BulletExitPoint { get; set; }
		[Property] public override GameObject bulletPrefab { get; set; }

		public override string FriendlyName { get { return "Pistol"; } }

		public override void Shoot()
		{
			var bulletClone = bulletPrefab.Clone( BulletExitPoint.Transform.Position );
			bulletClone.Transform.Rotation = Rotation.LookAt( GameObject.Transform.Rotation.Forward, Vector3.Up );
		}
	}
}
