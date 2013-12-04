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

	public Transform prefabFish;

	Mesh defaultMesh;

	public int fishToSpawn = 10;
	public float spawnRadius = 10f;
	public float spawnDepth = 30f;

	public Vector3 smallFish = new Vector3(.25f,.25f,.5f);
	public Vector3 mediumFish = new Vector3(.5f,.5f,1f);
	public Vector3 largeFish = new Vector3(1f, 1f, 2f);

	// Use this for initialization
	void Start () {
		defaultMesh = new Mesh();

		Vector3[] vertices = new Vector3[8];
		Vector2[] uvs = new Vector2[8];
		int [] tris = new int[12];


		vertices[0] = new Vector3(0, -.5f, -.5f);
		vertices[1] = new Vector3(0, .5f, -.5f);
		vertices[2] = new Vector3(0, .5f, .5f);
		vertices[3] = new Vector3(0, -.5f, .5f);

		vertices[4] = new Vector3(0, -.5f, -.5f);
		vertices[5] = new Vector3(0, .5f, -.5f);
		vertices[6] = new Vector3(0, .5f, .5f);
		vertices[7] = new Vector3(0, -.5f, .5f);

		uvs[0] = new Vector2(0,0);
		uvs[1] = new Vector2(0,1);
		uvs[2] = new Vector2(-1,1);
		uvs[3] = new Vector2(-1,0);

		uvs[4] = new Vector2(0,0);
		uvs[5] = new Vector2(0,1);
		uvs[6] = new Vector2(-1,1);
		uvs[7] = new Vector2(-1,0);

		tris[0] = 0;
		tris[1] = 1;
		tris[2] = 2;
		tris[3] = 0;
		tris[4] = 2;
		tris[5] = 3;

		tris[6] = 7;
		tris[7] = 6;
		tris[8] = 5;
		tris[9] = 7;
		tris[10] = 5;
		tris[11] = 4;


		defaultMesh.vertices = vertices;
		defaultMesh.uv = uvs;
		defaultMesh.triangles = tris;
		defaultMesh.RecalculateNormals();

		for(int i = 0 ; i < fishToSpawn; i++)
		{
			float randomAngle = Random.value * Mathf.PI * 2f;
			int randomSize = (int)(Random.value * 3f);

			GenerateFish(new Vector3(Mathf.Cos(randomAngle) * spawnRadius, Random.value * -spawnDepth, Mathf.Sin(randomAngle) * spawnRadius ), randomSize);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GenerateFish(Vector3 position, int size) {
		Transform newFish = (Transform)Instantiate(prefabFish, position, Quaternion.AngleAxis(Random.value * Mathf.PI * 2f, Vector3.up));
	
		if(size == 0)
		{
			newFish.transform.localScale = smallFish;
		}
		if(size == 1)
		{
			newFish.transform.localScale = mediumFish;
		}
		if(size == 2)
		{
			newFish.transform.localScale = largeFish;
		}

		((Fish)(newFish.GetComponent("Fish"))).size = size;

		MeshFilter meshF = newFish.GetComponent<MeshFilter>();
		meshF.mesh = defaultMesh;

		CreateRenderer(newFish.GetComponent<MeshRenderer>());
		((SetRenderQueue)newFish.GetComponent("SetRenderQueue")).refresh();
	}

	void CreateRenderer(MeshRenderer fishRenderer) {


		//Randomize attributes
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

		//Calculate the number of parts on each fish
		int numparts;
		numparts = 5;
		if (lantern) {
			numparts = 6;
		}

		//Generate the names for the random fish parts
		bodyTexName = "Body0" + body.ToString ();
		bottomTexName = "Bottom0" + bottom.ToString ();
		faceTexName = "Face0" + face.ToString ();
		tailTexName = "Tail0" + tail.ToString ();
		topTexName = "Top0" + top.ToString();
		lanternTexName = "Lantern";

		//Create an array of materials for the various fish parts
		Material[] materialsArray;

		if (lantern) {
			materialsArray = new Material[6];

			for(int i = 0; i < 6; i++) {
				materialsArray[i] = new Material(fishRenderer.material);
			}
		}
		else {
			materialsArray = new Material[5];
			
			for(int i = 0; i < 5; i++) {
				materialsArray[i] = new Material(fishRenderer.material);
			}

		}

		//Store the materials array into the fish
		//fish.renderer.materials = materialsArray;
		//MeshRenderer fishRenderer = fish.GetComponent<MeshRenderer>();
		fishRenderer.materials = materialsArray;

		//Add the textures to the fish materials list
		fishRenderer.materials[0].mainTexture = (Texture2D) Resources.Load(bodyTexName);
		fishRenderer.materials[1].mainTexture = (Texture2D) Resources.Load(bottomTexName);
		fishRenderer.materials[2].mainTexture = (Texture2D) Resources.Load(faceTexName);
		fishRenderer.materials[3].mainTexture = (Texture2D) Resources.Load(tailTexName);
		fishRenderer.materials[4].mainTexture = (Texture2D) Resources.Load(topTexName);
		
		if(lantern) {
			fishRenderer.materials[5].mainTexture = (Texture2D) Resources.Load(lanternTexName);
			
		}

		//Account for transparency for each part
		fishRenderer.materials[0].shader = Shader.Find("Unlit/Transparent");
		fishRenderer.materials[1].shader = Shader.Find("Unlit/Transparent");
		fishRenderer.materials[2].shader = Shader.Find("Unlit/Transparent");
		fishRenderer.materials[3].shader = Shader.Find("Unlit/Transparent");
		fishRenderer.materials[4].shader = Shader.Find("Unlit/Transparent");
		
		if(lantern) {
			fishRenderer.materials[5].shader = Shader.Find("Unlit/Transparent");
			
		}

		//Tint each fish aprt, pixel by pixel
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
			//Apply the tint to the current part
			(fishRenderer.materials[i].mainTexture as Texture2D).Apply();
		}

		


		//fish.GetComponent<MeshFilter>().mesh

	}
}
