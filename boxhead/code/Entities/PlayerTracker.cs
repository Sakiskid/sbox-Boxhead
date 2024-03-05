namespace Sandbox.Entities
{
	public static class PlayerTracker
	{
		public static List<PlayerInfo> Players = new List<PlayerInfo>();

		public static void AddPlayerToTrack( PlayerInfo player )
		{
			Players.Add( player );
		}
		
		public static void RemovePlayerToTrack( PlayerInfo player )
		{
			Players.Remove( player );
		}
	}
}
