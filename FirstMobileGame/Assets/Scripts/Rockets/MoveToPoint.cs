using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveToPoint : MonoBehaviour
{
	[SerializeField] private float speedMin = 1;
	[SerializeField] private float speedMax = 10;
	[SerializeField] private Vector3 pointToMove = new Vector2(0, 0);
	private Rigidbody2D body;
	public float speed{ get; private set; }
	public Vector2 direction { get; private set; }
	

	void Start()
	{
		//RestartPosition();
		body = GetComponent<Rigidbody2D>();
		SetDirectionToPoint();
		RestartSpeed();
		UpdateSpeed();
	}

	private void Awake()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}




	public void UpdateSpeed()
	{
		body.velocity = speed * direction.normalized;
	}


	public void SetSpeed (float newSpeed) => speed = newSpeed;

	public void SetDirection (Vector2 newDirection) =>	direction = newDirection;
	
	public void SetDirectionToPoint() => direction = pointToMove - transform.position;

	public void RestartSpeed() => speed = Random.Range(speedMin, speedMax);
	


	public void SetMinMaxSpeed(float newSpeedMin, float newSpeedMax)
	{
	  speedMin = newSpeedMin;
	  speedMax = newSpeedMax;
	}


}
