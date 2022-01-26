using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderGyroscopeCheck : MonoBehaviour
{
	[SerializeField] Slider sliderX;
	[SerializeField] Slider sliderY;
	[SerializeField] Slider sliderZ;
	[SerializeField] Slider sliderW;
	[SerializeField] InputRotationGyro input;
	// Start is called before the first frame update
	void Start()
    {
		input = GetComponent<InputRotationGyro>();

	
	}

    // Update is called once per frame
    void Update()
    {
		var rotation = GyroRotationInput.Instance.GetGyroGravity();
		//rotation = new Vector3(Mathf.Atan(rotation.x) * Mathf.Rad2Deg, Mathf.Asin(rotation.y) * Mathf.Rad2Deg, Mathf.Asin(rotation.z) * Mathf.Rad2Deg);
		sliderX.value = rotation.x;
		sliderY.value = rotation.y;
		sliderZ.value = rotation.z;
		sliderW.value = input.GetRotation();
	
	}
}
