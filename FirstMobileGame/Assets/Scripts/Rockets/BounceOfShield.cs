using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOfShield : DeathByShield, ICanHitShield
{

	[SerializeField] private int timeOfBouncesMin;
	[SerializeField] private int timeOfBouncesMax;
	private int timeOfBounces;

	[SerializeField] float timeUntilBounceBackMin;
	[SerializeField] float timeUntilBounceBackMax;

	[SerializeField] float bounceAngleMin;
	[SerializeField] float bounceAngleMax;

	[SerializeField] float speedPerBounce;

	[SerializeField] int scorePerBounce;
	private float bounceAngle;

	[SerializeField] ParticleSystem bounceParticles;

	//MoveToPoint moveToPoint;
    // Start is called before the first frame update
    void Start()
    {	
		moveToPoint = GetComponent<MoveToPoint>();
    }

	private void Awake()
	{
		timeOfBounces = Random.Range(timeOfBouncesMin, timeOfBouncesMax);
		rotationInput = GameObject.FindWithTag("Player").GetComponent<IRotationInput>();
	}
	// Update is called once per frame
	void Update()
    {
      
    }

	public override void OnShieldHit()
	{	if (timeOfBounces <= 0)
		{ Death(); ScoreScript.ChangeScore(scoreForKill); return; }

		ScoreScript.ChangeScore(scorePerBounce);
		bounceAngle = Random.Range(bounceAngleMin, bounceAngleMax);
		timeOfBounces--;
		if (moveToPoint != null)
		{
			moveToPoint.SetSpeed(-moveToPoint.speed);
			moveToPoint.SetDirection(Quaternion.AngleAxis(bounceAngle, Vector3.forward) * moveToPoint.direction);
			moveToPoint.UpdateSpeed();
			
		}


		CreateBouncyParticles();


		float timeUntilBouceBack = Random.Range(timeUntilBounceBackMin, timeUntilBounceBackMax);
		Invoke("BounceBackToPoint", timeUntilBouceBack);
	}

	private void BounceBackToPoint()
	{
		CreateBouncyParticles();
		moveToPoint.SetSpeed(Mathf.Abs(moveToPoint.speed) + speedPerBounce);
		moveToPoint.SetDirectionToPoint();
		moveToPoint.UpdateSpeed();
		
	}

	private void CreateBouncyParticles()
	{
		if (bounceParticles != null)
		{
			var particles = Instantiate(bounceParticles, transform.position, Quaternion.LookRotation(moveToPoint.direction));
			particles.transform.SetParent(null);
			Destroy(particles, particles.main.startLifetime.constant);
		}
	}
}
