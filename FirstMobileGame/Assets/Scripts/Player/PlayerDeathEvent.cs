using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathEvent : MonoBehaviour
{
	public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;
	public static void KillPlayer() => OnPlayerDeath();

	
}
