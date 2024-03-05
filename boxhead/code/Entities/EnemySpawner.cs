using System.Threading.Tasks;
using Sandbox;

public sealed class EnemySpawner : Component
{
	[Property] private GameObject EnemyToSpawnPrefab;
	[Property] private int MaxEnemiesAtOnce = 20;
	[Property] private float spawnInterval = 1f;
	private int currentEnemies = 0;
	
	protected override void OnStart()
	{
		_ = StartSpawning();
	}
	
	private async Task StartSpawning()
	{
		while ( true )
		{
			await Task.DelaySeconds( spawnInterval );
			SpawnEnemy();
		}
	}

	private void SpawnEnemy()
	{
		if ( EnemyToSpawnPrefab != null && currentEnemies < MaxEnemiesAtOnce)
		{
			currentEnemies++;
			EnemyToSpawnPrefab.Clone( Transform.Position );
		}
	}
}
