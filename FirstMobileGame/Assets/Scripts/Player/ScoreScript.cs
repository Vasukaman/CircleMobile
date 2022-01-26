using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScoreScript
{ 

	
	public static int score { get; private set; }
	public delegate void ChangeScoreAction();
	public static event ChangeScoreAction OnScoreChanged;
	public static void ChangeScore(int scoreChange)
	{
		score += scoreChange;
		if (Spawner.Instance != null)
			OnScoreChanged();
		
	}

	public static void RestartScore() => score = 0;

	
}
