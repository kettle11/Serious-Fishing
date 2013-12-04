using UnityEngine;
using System.Collections;

public class ShowEndScreen : MonoBehaviour {
	
	public Texture2D endMenuImage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {
		Rect screenRect = new Rect(0,0,Screen.width,Screen.height);

		GUI.DrawTexture(screenRect,endMenuImage,ScaleMode.ScaleToFit);
	}

}
