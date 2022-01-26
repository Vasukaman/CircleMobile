using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
	[SerializeField] private Vector3 baseRotation = new Vector3(0, 0, 1);
	private bool rotationInputExists = false;
	private IRotationInput rotationInput;
	[SerializeField] private float stabilizer;
	private float stabilize;
	private bool startStabilize=false;
	[SerializeField] private float startStabilizeTimer=1;

	private void Start()
	{
		rotationInput = GetComponent<IRotationInput>();

		if (rotationInput != null)
			rotationInputExists = true;
		else Debug.Log("No Rotation Input Found");

		
	}
	void Update()	
    {
		if (startStabilizeTimer > 0) startStabilizeTimer -= Time.deltaTime;
		else
			if (!startStabilize)
		{
			
			startStabilize = true;
		}


		if (rotationInputExists)
		{
			transform.eulerAngles= new Vector3 (0,0,rotationInput.GetRotation());
			
		}
    }

	
}
