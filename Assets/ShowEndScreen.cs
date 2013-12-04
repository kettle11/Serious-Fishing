using UnityEngine;
using System.Collections;

public class ShowEndScreen : MonoBehaviour {
	
	public Texture2D withDog;
	public Texture2D withoutDog;
	// Use this for initialization
	void Start () {
	
	}

	float offset = 0; 

	// Update is called once per frame
	void Update () {
		if((offset + 100)  > -withDog.height - 1430)
		{
			offset -= Time.deltaTime * 100;
		}
	}

	void OnGUI () {

		float scale = (float)Screen.width / (float)withDog.width;
	
		float y = offset;
		if(offset > -100)
		{
			y = 0;
		}
		else
		{
			y = offset + 100;
		}

		Rect screenRect = new Rect(0,y,withDog.width * scale,withDog.height * scale);

		if(FamilySceneGlobal.dog.alive)
		{
			GUI.DrawTexture(screenRect,withDog);
		}
		else
		{
			GUI.DrawTexture(screenRect,withoutDog);
		}
	}

}
