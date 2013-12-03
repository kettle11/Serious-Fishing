using UnityEngine;
using System.Collections;
//using System;

public class FishGenerator : MonoBehaviour {

	public int body;
	public int bottom;
	public int face;
	public int tail;
	public int top;
	public bool lantern;
	public Color color;

	private string bodyTexName;
	private string bottomTexName;
	private string faceTexName;
	private string tailTexName;
	private string topTexName;
	private string lanternTexName;

	// Use this for initialization
	void Start () {
		GenerateFish();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GenerateFish() {
		System.Random randgen = new System.Random();
		body = randgen.Next(1,7);
		bottom = randgen.Next(1,7);
		face = randgen.Next(1,7);
		tail = randgen.Next(1,7);
		top = randgen.Next(1,7);
		lantern = (randgen.Next(2) == 0);
		color.r = (float) randgen.NextDouble();
		color.g = (float) randgen.NextDouble();
		color.b = (float)randgen.NextDouble();
		
		bodyTexName = "Assets/Materials/Body0" + body.ToString () + ".png";
		bottomTexName = "Assets/Materials/Bottom0" + bottom.ToString () + ".png";
		faceTexName = "Assets/Materials/Face0" + face.ToString () + ".png";
		tailTexName = "Assets/Materials/Tail0" + tail.ToString () + ".png";
		topTexName = "Assets/Materials/Top0" + top.ToString () + ".png";
		lanternTexName = "Assets/Materials/Lantern.png";

		GameObject fish = new GameObject("fish");
		fish.AddComponent<MeshFilter> ();
		fish.AddComponent<MeshRenderer> ();


		Material[] materialsArray = new Material[6];

		for(int i = 0; i < 6; i++) {
			materialsArray[i] = new Material(fish.renderer.material);
		}

		MeshRenderer fishRenderer = fish.GetComponent<MeshRenderer>();
		fishRenderer.materials = materialsArray;

		fish.renderer.materials[0].mainTexture = (Texture2D) Resources.Load(bodyTexName);
		fish.renderer.materials[1].mainTexture = (Texture2D) Resources.Load(bottomTexName);
		fish.renderer.materials[2].mainTexture = (Texture2D) Resources.Load(faceTexName);
		fish.renderer.materials[3].mainTexture = (Texture2D) Resources.Load(tailTexName);
		fish.renderer.materials[4].mainTexture = (Texture2D) Resources.Load(topTexName);
		
		if(lantern) {
			fish.renderer.materials[5].mainTexture = (Texture2D) Resources.Load(lanternTexName);
			
		}


	}
}
