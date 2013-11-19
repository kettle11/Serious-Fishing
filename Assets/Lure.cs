using UnityEngine;
using System.Collections;

public class Lure : MonoBehaviour {

	ConfigurableJoint joint;

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
		//rigidbody.isKinematic = true;
	}

	public void unDeploy()
	{
		deployed = true;
		joint.xMotion = ConfigurableJointMotion.Limited;
		joint.yMotion = ConfigurableJointMotion.Limited;
		joint.zMotion = ConfigurableJointMotion.Limited;
		rigidbody.useGravity = true;
		//rigidbody.isKinematic = false;
	}

	bool inWater = false;
	public float waterGravity = -.05f;
	void FixedUpdate()
	{
		inWater = transform.position.y < 0;
		canBeUndeployed = inWater;
		if(inWater)
		{
			rigidbody.useGravity = false;
			rigidbody.AddForce(new Vector3(0,waterGravity,0));
			//rigidbody.velocity = rigidbody.velocity + new Vector3(0,waterGravity,0);
			rigidbody.drag = 5f;
		}
		else
		{
			rigidbody.useGravity = true;
		}
	}
	// Update is called once per frame
	void Update () {

	}
}
