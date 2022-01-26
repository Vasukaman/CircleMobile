using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateInTime : MonoBehaviour
{[SerializeField] float timeUntilDeactivation = 1;
	private float time;
	private void Awake()
	{
		time = timeUntilDeactivation;
		
	}

	private void Update()
	{
		if (time <= 0)
			Deactivate();
		else
			time -= Time.deltaTime;
	}

	private void Deactivate()
	{
		this.gameObject.SetActive(false);
	}
}
