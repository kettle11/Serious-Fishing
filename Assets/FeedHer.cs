using UnityEngine;
using System.Collections;

public class FeedHer : MonoBehaviour {
	bool alive = FamilySceneGlobal.wife.alive;

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
		if(!FamilySceneGlobal.wife.alive)
			gameObject.guiText.text = "    " + "DEAD";//gameObject.guiText.color = Color.white;
	}

	void OnMouseDown()
	{
		if (FamilySceneGlobal.wife.alive && tempFish!=0){
			FamilySceneGlobal.wife.feed();
		}
		else if(tempFish==0)
				Debug.Log("NO fish");
		else
			Debug.Log("She dead");

	}

	void OnMouseEnter() {
		if (FamilySceneGlobal.wife.alive)
		{
			gameObject.guiText.fontSize = 43;
			gameObject.guiText.color = Color.yellow;
		}
	}
	void OnMouseExit() {
		if (FamilySceneGlobal.wife.alive)
		{
			gameObject.guiText.fontSize = 34;
			gameObject.guiText.color = Color.white;
		}
	}

}
