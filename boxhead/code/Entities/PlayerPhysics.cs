using Sandbox;

public sealed class PlayerPhysics : Component
{
	[Property] public float friction;
	[Property] public float moveSpeed;

	[Property] private Vector3 inputDir;
	
	protected override void OnUpdate()
	{
		
	}
}
