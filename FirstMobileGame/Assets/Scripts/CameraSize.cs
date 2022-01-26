using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    [SerializeField] float maxCameraSize;
	[SerializeField] float minCameraSize;
	[SerializeField] float targetScore;
	[SerializeField] float resizeSpeed;
	Camera camera;
	float targetSize;

	private void Awake()
	{
		camera = GetComponent<Camera>();
	}

	private void Start()
	{
		UpdateTargetSize();
	}

	private void Update()
	{
		UpdateCameraSize();
	
	}

	private void UpdateCameraSize()
	{ camera.orthographicSize = Mathf.MoveTowards(camera.orthographicSize, targetSize, resizeSpeed*Time.deltaTime); }

	void UpdateTargetSize()
	{
		targetSize = Mathf.Lerp(minCameraSize, maxCameraSize, ScoreScript.score / targetScore);
	}

	private void OnEnable() => ScoreScript.OnScoreChanged += UpdateTargetSize;
	private void OnDisable() => ScoreScript.OnScoreChanged -= UpdateTargetSize;

}
