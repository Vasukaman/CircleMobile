using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{
	TMP_Text scoreText;
	Vector3 baseScale;
	float targetScale;
	float t;
	float target;
	[SerializeField] Vector3 maxScale;
	[SerializeField] float addT;
	[SerializeField] float addTdec;
	[SerializeField] float scalePerSecondInc;
	[SerializeField] float scalePerSecondDec;
	private void Awake()
	{	
		scoreText = GetComponent<TMP_Text>();
		baseScale = transform.localScale;
	}

	private void Start()
	{
		ScoreChange();  
	}

	private void Update()
	{
		ChangeScale();		
	}

	public void ScoreChange()
	{ scoreText.text = ScoreScript.score.ToString();
		StartChangeScaleAnimation();
	}

	public void UpdateTextScale(float scaleParameter)
	{
		Vector3 newScale;
		newScale.x = Mathf.Lerp(baseScale.x, maxScale.x, scaleParameter); 
		newScale.y = Mathf.Lerp(baseScale.y, maxScale.y, scaleParameter);
		newScale.z = Mathf.Lerp(baseScale.z, maxScale.z, scaleParameter);
		transform.localScale = newScale;
	}

	public void ChangeScale()
	{
		if (target > 0)
		{
			if (t < target)
			{
				t += scalePerSecondInc * Time.deltaTime*(addT-Mathf.Pow(Mathf.Lerp(-1,1, t), 2));
			}
			else target = 0;
		}
		else if (t > target)
		{
			t -= scalePerSecondDec * Time.deltaTime * (addTdec- Mathf.Pow(Mathf.Lerp(-1, 1, t), 2));
		}

		UpdateTextScale(t);
	}

	public void StartChangeScaleAnimation() => target = 1;

	private void OnEnable() => ScoreScript.OnScoreChanged += ScoreChange;

	private void OnDisable() => ScoreScript.OnScoreChanged -= ScoreChange;
}
