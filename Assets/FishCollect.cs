using UnityEngine;
using System.Collections;

public class FishCollect : MonoBehaviour {

	private static int fishCollected;
	public GameObject dog;

	public static void collectFish(int change)
	{
		fishCollected += change;
	}

	public static int getFishCollected()
	{
		return fishCollected;
	}

	// Use this for initialization
	void Start () {

		if(!FamilySceneGlobal.dog.alive)
		{
			Destroy(dog);
		}
	}

	void OnGUI() {
		GUI.Label(new Rect(100,100,100,100), "Fish: "+fishCollected);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
