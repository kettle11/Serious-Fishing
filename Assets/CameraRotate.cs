using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {

	public Texture2D startMenuImage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(Vector3.zero,Vector3.up, 4 * Time.deltaTime);
	
		if(Input.anyKeyDown) {
			Application.LoadLevel("RyanGimsonScene");
		}
	}

	void OnGUI() {
		Rect screenRect = new Rect(Screen.width / 2 - 400, -40, 800, 600);
		//GUI.Box (screenRect,startMenuImage);
		GUI.DrawTexture(screenRect,startMenuImage,ScaleMode.ScaleToFit);
	}
}
