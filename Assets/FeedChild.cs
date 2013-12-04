using UnityEngine;
using System.Collections;

public class FeedChild : MonoBehaviour {
	
	// replace this
	int tempFish;
	
	// Use this for initialization
	void Start () {
		tempFish = FamilySceneGlobal.fish;
	}
	public GameObject thing;
	// Update is called once per frame
	void Update () {
		tempFish = FamilySceneGlobal.fish;
		if(!FamilySceneGlobal.child.alive)
			gameObject.guiText.text = "    " + "DEAD";//gameObject.guiText.color = Color.white;
	}
	
	void OnMouseDown()
	{
		if (FamilySceneGlobal.child.alive && tempFish!=0){
			FamilySceneGlobal.child.feed();
		}
		else if(tempFish==0)
			Debug.Log("NO fish");
		
		
	}
	
	void OnMouseEnter() {
		if (FamilySceneGlobal.child.alive)
		{
			gameObject.guiText.fontSize = 43;
			gameObject.guiText.color = Color.yellow;
		}
	}
	void OnMouseExit() {
		if (FamilySceneGlobal.child.alive)
		{
			gameObject.guiText.fontSize = 34;
			gameObject.guiText.color = Color.white;
		}
	}

}
