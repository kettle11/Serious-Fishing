using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

	// Use this for initialization
	void Start () {
		direction = new Vector3(Random.value * 1f, 0f, Random.value * 1f).normalized;
		timer = Random.value;
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
	public float fov = 60f;

	public float timer;

	Vector3 velocity;

	Vector3 direction;

	public Transform target;

	public int outOfWaterLayer = 3021;
	public int inWaterLayer = 3019;

	public int size = 1;

	// Update is called once per frame
	//Much of this logic is assuming the boat position never moves!
	void Update () {

		if(transform.position.y < 0)
		{
			rigidbody.isKinematic = true;

		}
		else
		{
			rigidbody.isKinematic = false;
		}

		if(rigidbody.isKinematic)
		{
			timer += Time.deltaTime / rate;
			float value = movementPattern.Evaluate(timer);

			if(target != null && target.position.y < 0 && Vector3.Angle((target.position - transform.position), transform.forward) < fov)
			{
				direction = (target.position - transform.position).normalized;
			}

			velocity += value * acceleration * direction;

			if(velocity.magnitude > maxSpeed)
			{
				velocity = velocity.normalized * maxSpeed;
			}

			Vector3 oldDir = velocity.normalized;
			velocity -= velocity.normalized * friction * Time.deltaTime;

			//To prevent friction from accelerating backwards causing a flickering effect
			if(velocity.normalized != oldDir.normalized)
			{
				velocity = Vector3.zero;
			}

			//Also to prevent a flickering effect
			if(velocity.magnitude > 0)
			{
				transform.forward = velocity.normalized;
			}

			transform.position += velocity * Time.deltaTime;


			if(new Vector3(transform.position.x, 0, transform.position.z).magnitude > radius)
			{
				direction = (-new Vector3(transform.position.x, 0, transform.position.z)).normalized;
			}
		}
	}

	void OnTriggerEnter(Collider collidor) {

		if(collidor.GetComponent<Lure>())
		{
			collidor.GetComponent<Lure>().AttachFish(this);
		}
		//Destroy(gameObject);
	}
}
