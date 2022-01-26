using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusShield : MonoBehaviour,ICanHitPlayer
{
	[SerializeField] GameObject particles;
	[SerializeField] int scoreForCatching;

	public void  OnPlayerHit()
	{ GameObject.FindWithTag("BonusShield").transform.GetChild(0).gameObject.SetActive(true);
		Death();
	}


	public void Death()
	{
		ScoreScript.ChangeScore(scoreForCatching);
		Main.ChangeEnemyCount(-1);
		if (particles != null)
		{
			particles.transform.SetParent(null);
			var emission = particles.GetComponent<ParticleSystem>().emission;
			emission.rateOverTime = 0;
			Destroy(particles, 5);
		}

		Destroy(this.gameObject);
		//moveToPoint.RestartPosition();
		//moveToPoint.RestartSpeed();
	}

}
