using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollision : MonoBehaviour
{
	IRotationInput rotationInput;
	[SerializeField] bool isRecoil;


	private void OnCollisionEnter2D(Collision2D collision)
	{
		ICanHitShield shieldHitter = collision.gameObject.GetComponent<ICanHitShield>();

		if (shieldHitter != null)
		{
			shieldHitter.OnShieldHit();
			if (isRecoil) shieldHitter.OnShieldHitRecoil();
		}
		
	}
}
