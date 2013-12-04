using UnityEngine;
using System.Collections;

public class frameBaby : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(FamilySceneGlobal.baby.alive)
		{
			if(FamilySceneGlobal.baby.health>=FamilySceneGlobal.happy)
			{
				Texture my_img = (Texture)Resources.Load("BABYHAPPY");
				gameObject.renderer.material.mainTexture=my_img;
			}
			else{
				Texture my_img = (Texture)Resources.Load("BABYSAD");
				gameObject.renderer.material.mainTexture=my_img;
			}
		}
		else
		{
			Texture my_img = (Texture)Resources.Load("BABYDEAD");
			gameObject.renderer.material.mainTexture=my_img;
		}
	}
}
