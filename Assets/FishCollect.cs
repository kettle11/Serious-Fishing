using UnityEngine;
using System.Collections;

public class FishCollect : MonoBehaviour {

	private static int fishCollected;
	public GameObject dog;

	static float timer;
	static float timerMax = 3f;
	public static void collectFish(int change)
	{
		fishCollected += change;
		timer = timerMax;
	}

	public static int getFishCollected()
	{
		return fishCollected;
	}

	// Use this for initialization
	void Start () {
		fishCollected = 0;
		if(!FamilySceneGlobal.dog.alive)
		{
			Destroy(dog);
		}
	}

	public GUIStyle style;

	void OnGUI() {

		GUI.contentColor = Color.Lerp(Color.white, Color.clear, (timerMax - timer) / timerMax);

		if(timer > 0)
		{
			GUI.Label(new Rect(100,100,100,100), "Fish: "+fishCollected, style);
		}
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

	}
}
