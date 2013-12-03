using UnityEngine;
using System.Collections;

public class WaveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public float scale = 10.0f;
	public float speed = 1.0f;
	float noiseStrength = 4.0f;
	
	private Vector3[] baseHeight;
	
	void Update () {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		
		if (baseHeight == null)
			baseHeight = mesh.vertices;
		
		var vertices = new Vector3[baseHeight.Length];
		for (var i=0;i<vertices.Length;i++)
		{
			var vertex = baseHeight[i];
			vertex.y += Mathf.Sin(Time.time * speed+ baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;
			vertex.y += Mathf.PerlinNoise(baseHeight[i].x , baseHeight[i].y + Mathf.Sin(Time.time * 0.1f) ) * noiseStrength;
			vertices[i] = vertex;
		}
		mesh.vertices = vertices;
		mesh.RecalculateNormals();
	}
}
