using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustRotating2States : JustRotating
{
	[SerializeField] float state1;
	[SerializeField] float state2;
	[SerializeField] float changeStateSpeed;
	float targetRotationSpeed;

	private void Start()
	{
		targetRotationSpeed = state1;
	}
	private void Update()
	{
		UpdateRotation();
		UpdateSpeed();
		
	}

	void UpdateSpeed() => rotationSpeed = Mathf.MoveTowards(rotationSpeed, targetRotationSpeed, changeStateSpeed*Time.deltaTime);

	public void ChangeToState1() => targetRotationSpeed = state1;
	public void ChangeToState2() => targetRotationSpeed = state2;
}
