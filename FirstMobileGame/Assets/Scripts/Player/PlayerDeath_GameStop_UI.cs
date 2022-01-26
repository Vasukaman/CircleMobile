using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath_GameStop_UI : MonoBehaviour
{
	[SerializeField] GameObject UI;
	private void OnEnable()
	{
		PlayerDeathEvent.OnPlayerDeath += StopGame;
		PlayerDeathEvent.OnPlayerDeath += EnableUI;
	}

	private void OnDisable()
	{
		PlayerDeathEvent.OnPlayerDeath -= StopGame;
		PlayerDeathEvent.OnPlayerDeath -= EnableUI;
	}

	public void StopGame()
	{
		Time.timeScale = 0;
	}

	public void EnableUI()
	{
		UI.SetActive(true);
	}
}
