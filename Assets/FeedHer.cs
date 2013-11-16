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
			Debug.Log(thing.wife.name);
			//feed(wife)
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
