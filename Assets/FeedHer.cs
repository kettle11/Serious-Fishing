using UnityEngine;
using System.Collections;

public class FeedHer : MonoBehaviour {
	bool alive = true;
	// Use this for initialization
	void Start () {

	}
	public GameObject thing;
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		if (alive){
		
		}
	}

	void OnMouseEnter() {
		if (alive)
			gameObject.guiText.color = Color.red;
	}
	void OnMouseExit() {
		if (alive)
			gameObject.guiText.color = Color.black;
	}
}
