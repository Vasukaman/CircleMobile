using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRotationInput : MonoBehaviour
{
	private static GyroRotationInput instance;
	public static GyroRotationInput Instance
	{
		get
		{
			if (instance==null)
			{
				instance = FindObjectOfType<GyroRotationInput>();
				if (instance == null)
				{
					instance = new GameObject("Spawned InputRotation", typeof(GyroRotationInput)).GetComponent<GyroRotationInput>();
				}
			}
			return instance;
		}

		set
		{
			instance = value;
		}

	}



	private Vector3 rotation;
	private Gyroscope gyro;
	private bool gyroActive;
	

	void Update()
	{
		if (gyroActive)
		{
			rotation = gyro.attitude.eulerAngles;
		}
	}


	public Vector3 GetGyroRotation()
	{
		return rotation;
	}

	public Vector3 GetGyroGravity()
	{
		return gyro.gravity;
	}

	public void EnableGyro()
	{
		if (gyroActive) return;


		//if (SystemInfo.supportsGyroscope)
		//{
			gyro = Input.gyro;
			gyro.enabled = true;
			gyroActive = gyro.enabled;
	//	}
	//	else { Debug.Log("Gyro is not"); }
		
		//Debug.Log(gyro.updateInterval);
	}

	public Quaternion GetQuaternion()
	{
		return gyro.attitude;
	}

	public float GetRotationRate()
	{
		return gyro.rotationRateUnbiased.z;
	}
}
