using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour, ICanHitPlayer
{
	DeathByShield deathByShield;
	PlayerHealth playerHealth;
	private void Awake()
	{	
		deathByShield = GetComponent<DeathByShield>();
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}

	public void OnPlayerHit()
	{
		if (playerHealth != null)
		{
			if (playerHealth.health) playerHealth.healthTurnOff();
			else PlayerDeathEvent.KillPlayer();
		}
		else PlayerDeathEvent.KillPlayer();

		if(deathByShield!=null)
		deathByShield.Death();
	}



}
