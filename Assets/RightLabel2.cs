using UnityEngine;
using System.Collections;

public class RightLabel2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.guiText.fontSize = 34;
		gameObject.guiText.text= "\n\n";
		foreach( FamilySceneGlobal.Person x in FamilySceneGlobal.family)
		{
			if (x.alive)
			{
				gameObject.guiText.text += "  " + "Health: " + x.health + "    Hunger: " + x.hunger + '\n'+'\n'+'\n';
			}
		}
		
	
	}
}
