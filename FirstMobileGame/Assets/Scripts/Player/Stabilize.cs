using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabilize : MonoBehaviour
{
	float targetRotation;
	IRotationInput rotationInput;
	PlayerHealth playerHealth;
	private void Awake()
	{
		rotationInput = GetComponent<IRotationInput>();
		playerHealth = GetComponent<PlayerHealth>();
	}
	public void StabilizeRotation()
	{
		if (playerHealth != null && rotationInput != null)
		{
			if (playerHealth.health)
			{
				rotationInput.RestartRotation();
				playerHealth.healthTurnOff();
			}

		}
	}
}
