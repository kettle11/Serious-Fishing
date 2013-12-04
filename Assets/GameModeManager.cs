using UnityEngine;
using System.Collections;

public class GameModeManager : MonoBehaviour {

	enum GameState {
		Menu = 0,
		Fishing = 1,
		Family = 2,
		Story = 3,
	}
	

	public static Vector4 hunger;

	private bool pauseChange = false;
	public static bool paused = false;

	public MouseLook controller1;
	public MouseLook controller2;

	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad(transform.gameObject);



		hunger[0] = 10;
		//Application.LoadLevel("RyanTestScene");


	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P)) {
			paused = !paused;
			
			if(paused) {
				Time.timeScale = 0;
				controller1.enabled = false;
				controller2.enabled = false;

			}
			else {
				Time.timeScale = 1;
				controller1.enabled = true;
				controller2.enabled = true;
			}
		}
	}

	void OnGUI () {
		if(paused) {
			Rect newRect = new Rect(-10,-10,Screen.width + 20,Screen.height + 20);
			GUI.Button(newRect,"Paused");
		}
	}

}