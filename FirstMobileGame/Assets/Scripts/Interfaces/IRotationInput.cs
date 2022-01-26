using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotationInput
{
	float GetRotation();
	void AddRotationSpeed(float rot);
	void RestartRotation();
}

	
