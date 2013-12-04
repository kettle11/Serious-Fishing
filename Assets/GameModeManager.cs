using UnityEngine;
using System.Collections;

public class GameModeManager : MonoBehaviour {

	enum GameState {
		Menu = 0,
		Fishing = 1,
		Family = 2,
		Story = 3,
	}

	/*
	public enum FamilyMember {
		Wife = 0,
		Child = 1,
		Baby = 2,
		Dog = 3,
	}
	*/

	public static Vector4 hunger;

	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad(transform.gameObject);
		/*
		hunger[FamilyMember.Wife] = 10;
		hunger[FamilyMember.Child] = 10;
		hunger[FamilyMember.Baby] = 10;
		hunger[FamilyMember.Dog] = 10;
		*/

		hunger[0] = 10;
		//Application.LoadLevel("RyanTestScene");



	}


	// Update is called once per frame
	void Update () {
		
	}

}