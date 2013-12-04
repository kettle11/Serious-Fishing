using UnityEngine;
using System.Collections;

public class TimeKeepTracker : MonoBehaviour {

	int temp_fishCaught=FishCollect.getFishCollected();
	public static int day = 0;

	static float ltime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.deltaTime * 10;
		ltime+=t;
		//Debug.Log(ltime);
		if(ltime>360){
			ltime=0;
			day ++;

			//FamilySceneGlobal.set_fish(temp_fishCaught);
			if(day>7)
				Application.LoadLevel("EndSceen");
			else
				Application.LoadLevel("FamilyScene");
		}
	}
}
