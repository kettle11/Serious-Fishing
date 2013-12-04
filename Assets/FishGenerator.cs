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
		GenerateFish();
		GenerateFish();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GenerateFish() {
		GameObject fish = new GameObject("fish");

		System.Random randgen = new System.Random();
		body = randgen.Next(1,7);
		bottom = randgen.Next(1,7);
		face = randgen.Next(1,7);
		tail = randgen.Next(1,7);
		top = randgen.Next(1,7);
		lantern = (randgen.Next(2) == 0);
		color.r = (float) randgen.NextDouble();
		color.g = (float) randgen.NextDouble();
		color.b = (float) randgen.NextDouble();

		int numparts;
		numparts = 5;
		if (lantern) {
			numparts = 6;
		}
		
		bodyTexName = "Body0" + body.ToString ();
		bottomTexName = "Bottom0" + bottom.ToString ();
		faceTexName = "Face0" + face.ToString ();
		tailTexName = "Tail0" + tail.ToString ();
		topTexName = "Top0" + top.ToString();
		lanternTexName = "Lantern";

		fish.AddComponent<MeshFilter>();
		fish.AddComponent<MeshRenderer>();

		Material[] materialsArray;

		if (lantern) {
			materialsArray = new Material[6];

			for(int i = 0; i < 6; i++) {
				materialsArray[i] = new Material(fish.renderer.material);
			}
		}
		else {
			materialsArray = new Material[5];
			
			for(int i = 0; i < 5; i++) {
				materialsArray[i] = new Material(fish.renderer.material);
			}

		}

		fish.renderer.materials = materialsArray;

		MeshRenderer fishRenderer = fish.GetComponent<MeshRenderer>();
		fishRenderer.materials = materialsArray;

		Debug.Log(lanternTexName);
		if (Resources.Load(lanternTexName) == null) {
			Debug.Log("Not loading");
		}

		fishRenderer.materials[0].mainTexture = (Texture2D) Resources.Load(bodyTexName);
		fishRenderer.materials[1].mainTexture = (Texture2D) Resources.Load(bottomTexName);
		fishRenderer.materials[2].mainTexture = (Texture2D) Resources.Load(faceTexName);
		fishRenderer.materials[3].mainTexture = (Texture2D) Resources.Load(tailTexName);
		fishRenderer.materials[4].mainTexture = (Texture2D) Resources.Load(topTexName);


		
		if(lantern) {
			fishRenderer.materials[5].mainTexture = (Texture2D) Resources.Load(lanternTexName);
			
		}

		fishRenderer.materials[0].shader = Shader.Find("Unlit/Transparent");
		fishRenderer.materials[1].shader = Shader.Find("Unlit/Transparent");
		fishRenderer.materials[2].shader = Shader.Find("Unlit/Transparent");
		fishRenderer.materials[3].shader = Shader.Find("Unlit/Transparent");
		fishRenderer.materials[4].shader = Shader.Find("Unlit/Transparent");
		
		if(lantern) {
			fishRenderer.materials[5].shader = Shader.Find("Unlit/Transparent");
			
		}

		for(int i = 0; i < numparts; i++) {
			for(int x = 0; x < fishRenderer.materials[i].mainTexture.width; x++) {
				for(int y = 0; y < fishRenderer.materials[i].mainTexture.height; y++) {
					Color c = (fishRenderer.materials[i].mainTexture as Texture2D).GetPixel(x,y);
					c.r *= color.r;
					c.g *= color.g;
					c.b *= color.b;

					(fishRenderer.materials[i].mainTexture as Texture2D).SetPixel(x,y,c);
				}
			}
		(fishRenderer.materials[i].mainTexture as Texture2D).Apply();
		}


		Color cl = (fishRenderer.materials[0].mainTexture as Texture2D).GetPixel(50,50);
		cl.r *= color.r;
		cl.g *= color.g;
		cl.b *= color.b;
		Debug.Log(cl.r.ToString ());
		Debug.Log(cl.g.ToString ());
		Debug.Log(cl.b.ToString ());
		
		//Vector3 pos = new Vector3(0,2,-5);
		Debug.Log("test");
		fish.GetComponent<Transform>().position = new Vector3(0,2,-5);
		//fish.GetComponent<MeshFilter>().mesh

	}
}
