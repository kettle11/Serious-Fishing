using UnityEngine;
using System.Collections;

public class frameHer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(FamilySceneGlobal.wife.alive)
		{
			if(FamilySceneGlobal.wife.health>=FamilySceneGlobal.happy)
			{
				Texture my_img = (Texture)Resources.Load("WIFEHAPPY");
				gameObject.renderer.material.mainTexture=my_img;
			}
			else{
				Texture my_img = (Texture)Resources.Load("WIFESAD");
				gameObject.renderer.material.mainTexture=my_img;
			}
		}
		else
		{
			Texture my_img = (Texture)Resources.Load("WIFEDEAD");
			gameObject.renderer.material.mainTexture=my_img;
		}
	}
}
