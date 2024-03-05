namespace Sandbox.Entities
{
	public class PlayerInfo : Component
	{
		protected override void OnEnabled()
		{
			PlayerTracker.AddPlayerToTrack( this );
		}

		protected override void OnDisabled()
		{
			PlayerTracker.RemovePlayerToTrack( this );
		}
	}
}
