using UnityEngine;
using System.Collections;

public class Lure : MonoBehaviour {

	ConfigurableJoint joint;
	
	public AudioSource splashSound;
	public AudioSource barkSound;

	public Collider dogCollider;

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
		if(fishAttached)
		{
			fishOutOfWater = true;
		}
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

		//Cast fish back
		if(fishOutOfWater && deployed && newInWater && newInWater != inWater && fishAttached != null)
		{
			unDeploy();
			DetachFish();
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
	bool fishOutOfWater = false;

	void Update()
	{
		if(fishAttached != null)
		{
			fishAttached.transform.position = this.transform.position;
			fishAttached.transform.forward = this.transform.up;
		}


	}

	public void AttachFish(Fish fish)
	{
		//ConfigurableJoint joint = fish.GetComponent<ConfigurableJoint>();
		//joint.connectedBody = this.rigidbody;

		fish.rigidbody.isKinematic = true;
		fishAttached = fish;
		fishOutOfWater = false;

	}

	public void DetachFish()
	{
		if(fishAttached != null)
		{
			fishAttached.rigidbody.isKinematic = true;
			fishAttached.rigidbody.position = fishAttached.transform.position;
			fishAttached.rigidbody.velocity = Vector3.zero;
			fishAttached = null;
		}
	}

	void OnCollisionEnter(Collision collision) {
		if(deployed && collision.gameObject.GetComponent<BoatScript>() && fishAttached != null)
		{ 
			FishCollect.collectFish(fishAttached.size + 1);
			//Catch fish!
			unDeploy();
			DetachFish();


		}


	}
	void OnTriggerEnter(Collider collidor) {



	}

	public void BroughtOutOfWater() {
		if (fishAttached != null) {
			barkSound.Play();
		}
	}
}
