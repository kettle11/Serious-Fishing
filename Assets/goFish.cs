using UnityEngine;
using System.Collections;

public class goFish : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		// switch to fishing mode
		foreach( FamilySceneGlobal.Person x in FamilySceneGlobal.family)
		{
			if (x.alive)
				x.hunger += 1;
				x.health -= 3;
			if (x.health <= 0)
				x.alive = false;
		}
		Application.LoadLevel("IanScene");
	}
	void OnMouseEnter() {
			gameObject.guiText.color = Color.black;
	}
	void OnMouseExit() {
			gameObject.guiText.color = Color.yellow;
	}
}
