using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAmeraTest : MonoBehaviour
{
	[SerializeField] Transform newTransform;
	[SerializeField] Vector3 baseRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//transform.eulerAngles = new Vector3(newTransform.eulerAngles.x * baseRotation.x, newTransform.eulerAngles.y * baseRotation.y, newTransform.eulerAngles.z * baseRotation.z);
		//transform.localRotation = Quaternion.Euler( new Vector3(newTransform.eulerAngles.x * baseRotation.x, newTransform.eulerAngles.y * baseRotation.y, newTransform.eulerAngles.z * baseRotation.z));
	}
	private void LateUpdate()
	{
		Transform parent = transform.parent;
		transform.SetParent(null);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x * baseRotation.x, transform.eulerAngles.y*baseRotation.y, transform.eulerAngles.z * baseRotation.z);
		transform.SetParent(parent);
	}
}
