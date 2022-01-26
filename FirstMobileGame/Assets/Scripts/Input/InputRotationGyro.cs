using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRotationGyro : MonoBehaviour, IRotationInput
{

	public enum controllerTypes { gyroRotation, gyroRotationRateStabilized, screenSensor, }
	[SerializeField] float baseRotation = 90f;
	float stabilizeToWorldRotation;
	[SerializeField] float stabilization;
	[SerializeField] float differenceToStabilize;

	[SerializeField] float stabilizationZoneStart; //Каким-то образом переписать потом. Вероятно
	[SerializeField] float stabilizationZoneEnd;

	[SerializeField] controllerTypes controllerType;
	public delegate void ControllerTypeChangeAction();
	public ControllerTypeChangeAction onControllerTypeChange;


	float rotation;
	float dAttitude;
	float lastGravity;
	float stabilize;
	bool stabilized = false;
	float touchRotationSpeed;
	[SerializeField] float touchRotationSpeedPerSecond;

	float touchRotation;
	[SerializeField] float touchMoveSpeedModifier=1;
	[SerializeField] float touchSpeedModifier = 1;
	[SerializeField] float rotationSpeed;
	[SerializeField] float rotationSpeePerSecond;

	private void Update()
	{
		 UpdateRotationByRate();
		UpdateTouchRotation();
		UpdateRotationSpeed();

	}


	void Start()
	{
		GyroRotationInput.Instance.EnableGyro();
		rotation = baseRotation;
		//onControllerTypeChange += RewriteBaseRotation;
	}


	private float GetAttitudeRotation()
	{
		return GyroRotationInput.Instance.GetGyroRotation().z;
	}
	


	public void ControllerTypeChange(controllerTypes newControllerType)
	{ touchRotation = GetRotation();
		controllerType = newControllerType;
		
	
	}



	public void ControllerType1() => ControllerTypeChange(controllerTypes.gyroRotation);
	public void ControllerType2() => ControllerTypeChange(controllerTypes.gyroRotationRateStabilized);
	public void ControllerType3() => ControllerTypeChange(controllerTypes.screenSensor);



	public float GetRotation()
	{
		switch (controllerType)
		{
			case controllerTypes.gyroRotation:
				return GetAttitudeRotation() + baseRotation - stabilizeToWorldRotation;

			case controllerTypes.gyroRotationRateStabilized:
				return rotation + baseRotation; //- stabilizeToWorldRotation;
			case controllerTypes.screenSensor:
				return rotation;
				
				
		}
		Debug.Log("For some reason controller type is not coded");
		return 0;
	}


	private void UpdateRotationByRate()
	{
		dAttitude = GyroRotationInput.Instance.GetRotationRate();
																 
	
		lastGravity = GetGravityRotation();

		rotation += dAttitude;

		//Stabilize(stabilizationZoneStart,stabilizationZoneEnd);
		//Mathf.MoveTowards(rotation, lastGravity, Mathf.Abs(dAttitude) * stabilization);	//additionalStabilization
	}



	 void Stabilize(float startOfStabilizationZone, float endOfStabilizationZone) 
	{
		if((Mathf.Abs(rotation - lastGravity)) > differenceToStabilize)
		if (lastGravity > startOfStabilizationZone && lastGravity < endOfStabilizationZone)
		{
			if (!stabilized)
			{
				rotation = lastGravity;
				stabilized = true;
			}
		}
		else { stabilized = false; }
	}


	float GetGravityRotation()
	{
		Vector3 gravRotation = GyroRotationInput.Instance.GetGyroGravity();

		float xDegrees = (Mathf.Asin(gravRotation.x)) * Mathf.Rad2Deg + 90;

		if (gravRotation.y < 0) return 360 - xDegrees-180;
		else return 720 - xDegrees-180;
	}


	public void RewriteBaseRotation()
	{
		
		stabilizeToWorldRotation = GetRotation();
	}

	public void RestartRotation()
	{
		rotation = baseRotation;
	}

	public void UpdateTouchRotation()
	{
		if (Input.touchCount > 0)
		{
			var touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Moved)
			{ rotation += touch.deltaPosition.y * touchMoveSpeedModifier; }
			else if (touch.phase == TouchPhase.Ended)
			{
				touchRotationSpeed = touch.deltaPosition.y * touchSpeedModifier;
			}
		}
		else
		{
			rotation += touchRotationSpeed*Time.deltaTime;

			touchRotationSpeed = Mathf.MoveTowards(touchRotationSpeed, 0, touchRotationSpeedPerSecond * Time.deltaTime);
		}
		
	}

	public void AddRotationSpeed(float sp)
	{
		rotationSpeed += sp;
	}

	void UpdateRotationSpeed()
	{
		rotation += rotationSpeed*Time.deltaTime;
	rotationSpeed = Mathf.MoveTowards(rotationSpeed, 0, rotationSpeePerSecond*Time.deltaTime);
	}


}
