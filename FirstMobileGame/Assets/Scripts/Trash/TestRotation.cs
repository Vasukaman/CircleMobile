using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
	[SerializeField] Vector3 baseRotation;

	// Update is called once per frame
	void Update()
    {
		transform.rotation = GyroRotationInput.Instance.GetQuaternion();
		Debug.Log(Mathf.Sin((transform.eulerAngles.x+90) * Mathf.Deg2Rad));
		transform.eulerAngles = new Vector3(transform.eulerAngles.x * baseRotation.x, transform.eulerAngles.y * baseRotation.y, transform.eulerAngles.z * baseRotation.z * (Mathf.Sin( (transform.eulerAngles.x+90) * Mathf.Deg2Rad)));
		
	}
}
