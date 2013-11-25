using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

	// Use this for initialization
	void Start () {
		direction = new Vector3(Random.value * 1f, 0f, Random.value * 1f).normalized;
	}

	//The radius fish can roam within.
	public float radius = 8f;
	public float acceleration = 1f;
	public float maxSpeed = 6f;
	public float friction = 1f;
	//How the fish moves
	public AnimationCurve movementPattern;

	//How fast the fish moves through the movement curve
	public float rate = 5f;
	float timer = 0f;
	Vector3 velocity;

	Vector3 direction;

	// Update is called once per frame
	//Much of this logic is assuming the boat position never moves!
	void Update () {
		timer += Time.deltaTime / rate;
		float value = movementPattern.Evaluate(timer);

		velocity += value * acceleration * direction;

		if(velocity.magnitude > maxSpeed)
		{
			velocity = velocity.normalized * maxSpeed;
		}

		velocity -= velocity.normalized * friction * Time.deltaTime;

		transform.position += velocity * Time.deltaTime;
		transform.forward = -direction;

		if(transform.position.magnitude > radius)
		{
			direction = (-new Vector3(transform.position.x, 0, transform.position.z)).normalized;

		}
	}
}
