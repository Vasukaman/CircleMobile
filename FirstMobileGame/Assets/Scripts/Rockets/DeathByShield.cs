using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByShield : MonoBehaviour, IKillable, ICanHitShield
{
	protected MoveToPoint moveToPoint;
	[SerializeField] protected int scoreForKill;
	[SerializeField] GameObject particles;
	[SerializeField] GameObject deathParticles;
	[SerializeField] Vector3 deathParticlesOffset;
	protected IRotationInput rotationInput;
	[SerializeField] float maxRecoil;
	[SerializeField] float minRecoil;

	// Start is called before the first frame update
	void Start()
	{
		moveToPoint = GetComponent<MoveToPoint>();
		rotationInput = GameObject.FindWithTag("Player").GetComponent<IRotationInput>();
	}


	public void Death()
	{
		
		Main.ChangeEnemyCount(-1);
		if (particles != null)
		{
			particles.transform.SetParent(null);
			var emission = particles.GetComponent<ParticleSystem>().emission;
			emission.rateOverTime = 0;
			Destroy(particles, 5);
		}

		if (deathParticles != null)
		{
			deathParticles = Instantiate(deathParticles, transform);
			deathParticles.transform.SetParent(null);
			deathParticles.transform.position = particles.transform.position;// deathParticlesOffset; //œ–Œ¬≈– » “¿Ã »À» ◊“Œ-“Œ
			
			Destroy(deathParticles, deathParticles.GetComponent<ParticleSystem>().main.startLifetime.constant);
		}
		
		Destroy(this.gameObject);

	
	}

	public virtual void OnShieldHit()
	{

		Death();
		ScoreScript.ChangeScore(scoreForKill);
	}

	public void OnShieldHitRecoil()
	{ ApplyRandomRecoil(); }
		

	private void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position, transform.position + deathParticlesOffset);
	}


	protected void ApplyRandomRecoil()
	{
		rotationInput.AddRotationSpeed(Random.Range(minRecoil,maxRecoil) * Main.RandomSign());//Random.Range(-maxRecoil, maxRecoil));
	}

}
