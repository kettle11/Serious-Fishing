using UnityEngine;
using System.Collections;

public class frameDog : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(FamilySceneGlobal.dog.alive)
		{
			if(FamilySceneGlobal.dog.health>=FamilySceneGlobal.happy)
			{
				Texture my_img = (Texture)Resources.Load("DOGHAPPY");
				gameObject.renderer.material.mainTexture=my_img;
			}
			else{
				Texture my_img = (Texture)Resources.Load("DOGSAD");
				gameObject.renderer.material.mainTexture=my_img;
			}
		}
		else
		{
			Texture my_img = (Texture)Resources.Load("DOGDEAD");
			gameObject.renderer.material.mainTexture=my_img;
		}
	}
}
