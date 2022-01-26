using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Main
{
	
	public static int enemyCount { get; private set; }

	public static void ChangeEnemyCount(int value)
	{
		enemyCount += value;
	}

	public static void RestartEnemyCount()
	{
		enemyCount =0;
	}

	public static void RestartLevel()
	{
		ScoreScript.RestartScore();
		Main.RestartEnemyCount();
		SceneManager.LoadScene("SampleScene");
		Time.timeScale = 1;
		
	}



	public static int RandomSign()
	{
		if (Random.value > 0.5)
		{
			return 1;
		}
		return -1;
	}

	
}
