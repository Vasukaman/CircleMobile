using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassRotationInput : MonoBehaviour
{

	private static CompassRotationInput instance;
	public static CompassRotationInput Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<CompassRotationInput>();
				if (instance == null)
				{
					instance = new GameObject("Spawned InputCompass", typeof(CompassRotationInput)).GetComponent<CompassRotationInput>();
				}
			}
			return instance;
		}

		set
		{
			instance = value;
		}

	}




	private float rotation;
	private Compass compass;
	private bool compassActive;


	void Update()
	{
		//if (compassActive)
		//{
			rotation = compass.trueHeading;
		//}
	}


	public float GetCompassRotation()
	{
		return rotation;
	}


	public void EnableCompass()
	{
		if (compassActive) return;


		//if (SystemInfo.supportsGyroscope)
		//{
		compass = Input.compass;
		compass.enabled = true;
		compassActive = compass.enabled;
		//	}
		//	else { Debug.Log("Gyro is not"); }


	}

}

