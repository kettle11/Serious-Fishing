using UnityEngine;
using System.Collections;

public class BoatScript : MonoBehaviour {

	Vector3 basePosition;

	// Use this for initialization
	void Start () {
		basePosition = transform.position;
	}

	public WaveScript waves;

	public float heightAboveWater = .3f;

	// Update is called once per frame
	void Update () {
		transform.up = waves.getNormalAtPoint(transform.position);
		transform.position =  new Vector3(basePosition.x, waves.getHeightAtPoint(transform.position), basePosition.z) + transform.up * heightAboveWater;
	}
}
