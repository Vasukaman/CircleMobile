using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, IScoreChangeAffected
{
	[System.Serializable]
	private class EnemyToSpawn
	{
		public GameObject enemy;
		public int scoreToSpawn;
		public float basePriority;
		public float priority;
		public float priorityPerScore;
		public float priorityPerSpawn;

		public EnemyToSpawn(GameObject enemy, int scoreToSpawn, float basePriority, float priorityPerScore, float priorityPerSpawn)
		{
			this.enemy = enemy;
			this.scoreToSpawn = scoreToSpawn;
			this.basePriority = basePriority;
			this.priority = this.basePriority;
			this.priorityPerScore = priorityPerScore;
			this.priorityPerSpawn = priorityPerSpawn;

		}
	}



	 public static Spawner Instance { get; private set; }
	[SerializeField] private Vector3 spawnCenter;
	[SerializeField] float minRadius;
	[SerializeField] float maxRadius;
	
	[SerializeField] private int startEnemyCount;
	[SerializeField] private int maxMaxEnemyCount;

	private int enemyCount;
	private int maxEnemyCount;
	[SerializeField] float minSpawnAngle;
	[SerializeField] float maxSpawnAngle;

	private float spawnAngle;

	[SerializeField] float targetScore;

	[SerializeField]  List<EnemyToSpawn> enemies;




	private void OnEnable() => ScoreScript.OnScoreChanged += ScoreChange;

	private void OnDisable() => ScoreScript.OnScoreChanged -= ScoreChange;


	void Start()
    {

		Instance = this;

	}

	public void StartSpawner()
    {
		Main.RestartEnemyCount();
		
		maxEnemyCount = startEnemyCount;
	}

    // Update is called once per frame
    void Update()
    {
		if (Main.enemyCount < maxEnemyCount) SpawnNewEnemy();
		enemyCount = Main.enemyCount;
    }


	void SpawnNewEnemy()
	{
		EnemyToSpawn enemyToSpawn = GetRandomEnemyBasedOnPriority();
		enemyToSpawn.priority += enemyToSpawn.priorityPerSpawn;
		GameObject spEnemy = enemyToSpawn.enemy;
		float spRadius = Random.Range(minRadius, maxRadius) * Main.RandomSign();
		float spAngle = Random.Range(0 - spawnAngle / 2, spawnAngle / 2)+90; //Эти переменные нужны чтоб было понятнее что происходит
		SpawnEnemy(spEnemy, CircleCoord(spawnCenter, spRadius, spAngle));

		Main.ChangeEnemyCount(1);

	}


	EnemyToSpawn GetRandomEnemyBasedOnPriority()
	{
		
		float fullPriority = 0;
		foreach (EnemyToSpawn enemy in enemies)
		{
			if (enemy.scoreToSpawn == ScoreScript.score) //Первое появление нового врага
				return enemy;

			if (enemy.scoreToSpawn < ScoreScript.score && enemy.priority > 0)
				fullPriority += enemy.priority;
		}
				float choosenPriority = Random.Range(0, fullPriority);

				fullPriority = 0;

				foreach (EnemyToSpawn enemy in enemies)
				{
					if (enemy.scoreToSpawn < ScoreScript.score)
					{
						fullPriority += enemy.priority;
						if (choosenPriority <= fullPriority)
							return enemy;
					}
				}
			
		Debug.Log("For some reason Couldn't choose Enemy based on Priority in Spawner.GetRandomEnemyBasedOnPriority");
		return enemies[0];

	}

	void SpawnEnemy(GameObject enemyToSpawn, Vector3 spawnPoint)
	{ Instantiate(enemyToSpawn, spawnPoint, new Quaternion(0, 0, 0, 0)); }





	Vector3 CircleCoord(Vector3 center, float radius, float angle)
	{
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
		pos.y = center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
		pos.z = center.x;
		return pos;
	}

	public void ScoreChange()
	{
		UpdatePriority();
		UpdateMaxEnemyCount();
		UpdateSpawnAngle();
	}

	private void UpdatePriority()
	{
		foreach (EnemyToSpawn enemy in enemies)
		{
			enemy.priority += enemy.priorityPerScore;
		}
	}

	private void UpdateMaxEnemyCount()
	{
		maxEnemyCount =(int) (ScoreScript.score / targetScore * (maxMaxEnemyCount-startEnemyCount) + startEnemyCount);  //Находит процент очков от таргета и пропорционально меняет максимум врагов
	}

	private void UpdateSpawnAngle()
	{
		spawnAngle = (ScoreScript.score / targetScore * (maxSpawnAngle - minSpawnAngle) + minSpawnAngle);  //Находит процент очков от таргета и пропорционально меняет угл спавна
	}


}
