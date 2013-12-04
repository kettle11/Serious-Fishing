using UnityEngine;
using System.Collections;

public class frameChild : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(FamilySceneGlobal.child.alive)
		{
			if(FamilySceneGlobal.child.health>=FamilySceneGlobal.happy)
			{
				Texture my_img = (Texture)Resources.Load("CHILDHAPPY");
				gameObject.renderer.material.mainTexture=my_img;
			}
			else{
				Texture my_img = (Texture)Resources.Load("CHILDSAD");
				gameObject.renderer.material.mainTexture=my_img;
			}
		}
		else
		{
			Texture my_img = (Texture)Resources.Load("CHILDDEAD");
			gameObject.renderer.material.mainTexture=my_img;
		}
	}
}
