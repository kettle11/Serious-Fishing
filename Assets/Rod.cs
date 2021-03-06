﻿using UnityEngine;
using System.Collections;

public class Rod : MonoBehaviour {


	ConfigurableJoint lureAttach;

	float defaultRotation = 80f;

	// Use this for initialization
	void Start () {
		lureAttach = currentLure.GetComponent<ConfigurableJoint>();

	}


	public Lure lurePrefab;

	public Lure currentLure;

	public AudioSource reelingSound;
	public AudioSource castSound;

	private bool reeling = false;

	public Camera lureCam;
	public float pullbackRotation = 0f;
	float currentPull = 0f;

	float lureDistanceFromBoat;

	public Transform firstPersonController;

	public float maxPullback = -100f;
	// Update is called once per frame
	void Update () {
		if(!GameModeManager.paused) {

			transform.localRotation = Quaternion.AngleAxis(defaultRotation + currentPull, Vector3.right);// * Quaternion.AngleAxis(90f, Vector3.up);
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
				//transform.localRotation = defaultRotation;
			}

			if(Input.GetMouseButton(0))
			{
				if(currentPull > maxPullback)
				{
					currentPull -= 1f;
				}
			}
			else
			{
				if(currentPull != 0)
				{
					cast ();
					castSound.Play();
					currentPull = 0f;
				}
			}

			if(currentLure.transform.position.y > 0 && reelingIn && currentLure.deployed)
			{
				unCast ();
				currentLure.BroughtOutOfWater();
			}

			//If the lure has just entered the water
			if(currentLure.deployed && currentLure.transform.position.y < 0 && lureCam.enabled == false)
			{
				lureDistanceFromBoat = currentLure.transform.position.magnitude;//Assumes boat is at 0,0,0

				lureCam.enabled = true;
				Camera.main.rect = new Rect(0,0,.5f,1f);
				
				//Why does right work?
				lureCam.transform.position = new Vector3(transform.right.x*lureCamDistance, lureCam.transform.position.y, transform.right.z*lureCamDistance);
				lureCam.transform.LookAt(new Vector3(transform.position.x, lureCam.transform.position.y, transform.position.z));
			}

			reelingIn = Input.GetMouseButton(1);

			//Handle playing reeling sound
			if(reelingIn && currentLure.deployed && !(reelingSound.isPlaying)) {
				reeling = true;
			}

			if(reeling) {
				reelingSound.Play();
				reeling = false;
			}

			if(!reelingIn) {
				reelingSound.Pause();
			}

			lureAngle = Mathf.Deg2Rad * firstPersonController.localRotation.eulerAngles.y;
			//Debug.Log(lureAngle);

			if(currentLure.deployed && currentLure.transform.position.y < 0)
			{

				currentLure.transform.position = new Vector3(Mathf.Cos(-lureAngle)*-lureDistanceFromBoat, currentLure.transform.position.y, Mathf.Sin(-lureAngle)*-lureDistanceFromBoat);
			}

			if(reelingIn && currentLure.rigidbody.velocity.y < maxReelRate)
			{
				currentLure.velocity += (new Vector3(0,reelRate,0)) * Time.deltaTime;
			}

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

	}

	private float lureAngle; 
	public float lureCamDistance = 15;
	bool locked;

	void cast() {
		lureAngle = transform.rotation.y;
		currentLure.deploy();
		currentLure.rigidbody.AddForce((transform.parent.forward + transform.parent.up * .6f).normalized * Mathf.Abs(currentPull) * 3f);
		locked = true;



	}

	void unCast() {
		currentLure.unDeploy();
		Camera.main.rect = new Rect(0,0,1f,1f);
		lureCam.enabled = false;
		locked = false;
		reelingSound.Pause();

	}

	bool reelingIn = false;
	public float reelRate = .1f;
	public float maxReelRate = .6f;

	void FixedUpdate()
	{
		if(currentLure.deployed)
		{

		}


	}


}
