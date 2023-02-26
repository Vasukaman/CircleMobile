using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] float healTime;
	public bool health { get; private set; } = true;
	[SerializeField] JustRotating2States rotationController;
	[SerializeField] SizeController sizeController;
	[SerializeField] ParticleSystemForceField particleSystemForceField;


	public void healthTurnOn()
	{
		health = true;
		if (rotationController != null)
		{
			rotationController.ChangeToState1();
			sizeController.ChangeToState1();
		}

		if (particleSystemForceField != null)
			particleSystemForceField.gameObject.SetActive(false);
	}

	public void healthTurnOff()
	{
		health = false;
		Invoke("healthTurnOn", healTime);

		if (rotationController != null)
		{
			rotationController.ChangeToState2();
			sizeController.ChangeToState2();
		}

		if (particleSystemForceField != null)
			particleSystemForceField.gameObject.SetActive(true);
	}
}
