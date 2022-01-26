using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath_RestartLevel : MonoBehaviour
{
	private void OnEnable() =>	PlayerDeathEvent.OnPlayerDeath += Main.RestartLevel;
	private void OnDisable() => PlayerDeathEvent.OnPlayerDeath -= Main.RestartLevel;
}
