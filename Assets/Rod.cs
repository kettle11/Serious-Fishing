using UnityEngine;
using System.Collections;

public class Rod : MonoBehaviour {


	ConfigurableJoint lureAttach;

	Quaternion defaultRotation;
	// Use this for initialization
	void Start () {
		lureAttach = currentLure.GetComponent<ConfigurableJoint>();
		defaultRotation = transform.localRotation;
	}


	public Lure lurePrefab;

	public Lure currentLure;

	public Camera lureCam;
	public float pullbackRotation = 260f;

	// Update is called once per frame
	void Update () {
	
		Ray ray = lureCam.ScreenPointToRay(Input.mousePosition - new Vector3(0,50));

		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 2))
		{
			if(hit.collider.GetComponent("Boat") || true)
			{
				//transform.localRotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, pullbackRotation));
			}

			Debug.DrawLine(ray.origin, hit.point);
		}
		else
		{
			transform.localRotation = defaultRotation;
		}

		if(Input.GetMouseButtonDown(0))
		{
			cast();
		}

		if(currentLure.transform.position.y > 0 && currentLure.canBeUndeployed)
		{
			unCast ();
		}

		reelingIn = Input.GetMouseButton(1);

		Ray mouseRay = lureCam.ScreenPointToRay(Input.mousePosition);

		/*
		Vector3 normal = transform.position - currentLure.transform.position;
		normal = new Vector3(normal.x, 0, normal.z).normalized;
		Plane p = new Plane(normal, currentLure.transform.position);
		float rayDistance = 0f;
		if (p.Raycast(mouseRay, out rayDistance))
		{
			Vector3 newPoint = mouseRay.direction * rayDistance;
			currentLure.rigidbody.velocity += (newPoint - rigidbody.transform.position) * .2f;
		}
		*/

	}
	
	void cast() {
		currentLure.deploy();
		lureCam.enabled = true;
		Camera.main.rect = new Rect(0,0,.5f,1f);
	}

	void unCast() {
		currentLure.unDeploy();
		Camera.main.rect = new Rect(0,0,1f,1f);
		lureCam.enabled = false;
	}

	bool reelingIn = false;
	public float reelRate = .1f;
	public float maxReelRate = .6f;

	void FixedUpdate()
	{
		if(currentLure.deployed)
		{

		}

		if(reelingIn && currentLure.rigidbody.velocity.y < maxReelRate)
		{
			currentLure.rigidbody.AddForce(new Vector3(0,reelRate,0));
		}
	}


}
