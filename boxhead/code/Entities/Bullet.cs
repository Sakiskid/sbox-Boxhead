using Sandbox;

public sealed class Bullet : Component
{
	[Property] public float Speed { get; set; }
	
	protected override void OnUpdate()
	{
		Transform.Position += Transform.Rotation.Forward * Speed * Time.Delta;
	}
}
