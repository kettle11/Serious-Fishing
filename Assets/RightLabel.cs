using UnityEngine;
using System.Collections;

public class RightLabel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

/*
	void OnMouseEnter() {
		gameObject.guiText.color = Color.red;
	}
	void OnMouseExit() {
		gameObject.guiText.color = Color.white;
	}
*/

	// Update is called once per frame
	void Update () {
		//pseudo code (foreach member in family) check if alive, print their shit 
		//gameObject.guiText.color = Color.magenta;

		gameObject.guiText.text = "Fish: " + FamilySceneGlobal.fish + '\n';

		foreach( FamilySceneGlobal.Person x in FamilySceneGlobal.family)
		{
			if (x.alive)
				gameObject.guiText.text += x.name + '\n';
				gameObject.guiText.fontSize = 47;
		}
	
	}
}
