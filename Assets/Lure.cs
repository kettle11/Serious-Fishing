using UnityEngine;
using System.Collections;

public class Lure : MonoBehaviour {

	ConfigurableJoint joint;
	
	public AudioSource splashSound;

	// Use this for initialization
	void Start () {
		joint = gameObject.GetComponent<ConfigurableJoint>();
	}

	public bool deployed = false;
	public bool canBeUndeployed = false;

	public void deploy()
	{
		deployed = true;
		joint.xMotion = ConfigurableJointMotion.Free;
		joint.yMotion = ConfigurableJointMotion.Free;
		joint.zMotion = ConfigurableJointMotion.Free;
		//rigidbody.velocity = new Vector3(0,0,0);
		rigidbody.useGravity = false;
		inWater = true;
		rigidbody.isKinematic = false;
	}

	public void unDeploy()
	{
		deployed = false;
		joint.xMotion = ConfigurableJointMotion.Limited;
		joint.yMotion = ConfigurableJointMotion.Limited;
		joint.zMotion = ConfigurableJointMotion.Limited;
		rigidbody.useGravity = true;
		rigidbody.isKinematic = false;
		inWater = false;

		//Reset kinemetic velocity
		velocity = Vector3.zero;
	}

	bool inWater = false;
	public float waterGravity = -.05f;
	public float maxSpeed = 9f;

	public Vector3 velocity;

	public WaveScript waves;
	void FixedUpdate()
	{
		bool newInWater = transform.position.y < waves.getHeightAtPoint(transform.position);

		if(newInWater != inWater && newInWater == true)
		{
			velocity = rigidbody.velocity;
			splashSound.Play();
		}

		inWater = newInWater;
		canBeUndeployed = inWater;

		if(inWater && deployed)
		{
			rigidbody.useGravity = false;
			rigidbody.AddForce(new Vector3(0,waterGravity,0));
			velocity += new Vector3(0,waterGravity,0) * Time.deltaTime;

			rigidbody.isKinematic = true;
			if(velocity.magnitude > maxSpeed)
			{
				velocity = velocity.normalized * maxSpeed;
			}
			transform.position += velocity * Time.deltaTime;
		}
		else
		{
			rigidbody.useGravity = true;
			rigidbody.isKinematic = false;
		}
	}

	Fish fishAttached;

	void Update()
	{
		if(fishAttached != null)
		{
			fishAttached.transform.position = this.transform.position;
		}
	}

	public void AttachFish(Fish fish)
	{
		//ConfigurableJoint joint = fish.GetComponent<ConfigurableJoint>();
		//joint.connectedBody = this.rigidbody;

		fish.rigidbody.isKinematic = true;
		fishAttached = fish;

	}

	void OnTriggerEnter(Collider collidor) {



	}
	
}
