using UnityEngine;
using System.Collections;

public class FishCollect : MonoBehaviour {

	private static int fishCollected;
	public GameObject dog;

	static float timer;
	static float timer2;

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
		timer2 = timerMax;

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

		GUI.contentColor = Color.Lerp(Color.white, Color.clear, (timerMax - timer2) / timerMax);
		GUI.Label(new Rect(Screen.width / 2f - 50f,Screen.height / 2f - 50f,100,100), "Day: "+ (TimeKeepTracker.day + 1), style);
	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		timer2 -= Time.deltaTime;

	}
}
