using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		ICanHitPlayer playerHitter = collision.gameObject.GetComponent<ICanHitPlayer>();

		if (playerHitter != null)
			playerHitter.OnPlayerHit();
	}
}
