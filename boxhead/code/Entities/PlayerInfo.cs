namespace Sandbox.Entities
{
	public class PlayerInfo : Component
	{
		[Sync][Property] int ColorIndex { get; set; }
		[Property] List<Color> Colors { get; set; }
		[Property] private GameObject PlayerModelObj { get; set; }

		protected override void OnStart()
		{
			ColorIndex = Game.Random.Int( 0, Colors.Count - 1 );
			PlayerModelObj.Components.Get<SkinnedModelRenderer>().Tint = Colors[ColorIndex];
		}

		protected override void OnUpdate()
		{
			PlayerModelObj.Components.Get<SkinnedModelRenderer>().Tint = Colors[ColorIndex];
			if ( IsProxy )
				return;
		}

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
