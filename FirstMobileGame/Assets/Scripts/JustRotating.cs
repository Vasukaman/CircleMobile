using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustRotating : MonoBehaviour
{

	[SerializeField] protected float rotationSpeed = 0;

	// Update is called once per frame
	void Update()
    {
		UpdateRotation();
    }

	public float GetRotationSpeed()
	{ return rotationSpeed; }


	public void SetRotationSpeed(float newSpeed)
	{
		rotationSpeed = newSpeed;
	}

	protected void UpdateRotation() => transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
}
