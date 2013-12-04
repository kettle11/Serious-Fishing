using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class WaveScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
		List<Vector3> vertices = new List<Vector3>();
		List<int> tris = new List<int>();

		for(int j = 0; j < depth; j++)
		{
			for(int i = 0; i < width; i++)
			{
				vertices.Add(new Vector3(i, 0, j));
			}
		}

		for(int j = 0; j < (depth - 1); j++)
		{
			for(int i = 0; i < (width - 1); i++)
			{
				print(i < width - 1);
				print(i);
				print(width);
				tris.Add(j * width + i);
				tris.Add((j + 1) * width + i);
				tris.Add(j * width + (i + 1));
				
				tris.Add((j + 1) * width + i);
				tris.Add((j + 1) * width + (i + 1));
				tris.Add(j * width + (i + 1));
			}
		}

		mesh.vertices = vertices.ToArray();;
		mesh.triangles = tris.ToArray();
		mesh.RecalculateNormals();
	}

	public float scale = 10.0f;
	public float speed = 1.0f;
	float noiseStrength = 4.0f;
	
	private Vector3[] baseHeight;

	public int width = 10;
	public int depth = 10;

	public float getHeightAtPoint(Vector3 point)
	{
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;

		point = point - transform.position;
		point = new Vector3(point.x / transform.localScale.x, point.y / transform.localScale.y, point.z / transform.localScale.z);

		int x = (int)point.x;
		int z = (int)point.z;
			
		int xPlusOne = x + 1;
		int zPlusOne = z + 1;

		if(xPlusOne > width || zPlusOne > depth || x < 0 || z < 0)
		{
			return 0f;
		}

		float triZ0 = (vertices[z * depth + x].y);
		float triZ1 = (vertices[z * depth + xPlusOne].y);
		float triZ2 = (vertices[zPlusOne * depth + x].y);
		float triZ3 = (vertices[zPlusOne * depth + xPlusOne].y);
		
		float height = 0.0f;
		float sqX = point.x - x;
		float sqZ = point.z - z;

		if ((sqX + sqZ) < 1)
		{
			height = triZ0;
			height += (triZ1 - triZ0) * sqX;
			height += (triZ2 - triZ0) * sqZ;
		}		
		else
		{
				
			height = triZ3;
			height += (triZ1 - triZ3) * (1.0f - sqZ);
			height += (triZ2 - triZ3) * (1.0f - sqX);
		}

		return height;

	}

	//A lot of overlap with getHeightAtPoint
	public Vector3 getNormalAtPoint(Vector3 point)
	{
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		
		point = point - transform.position;
		point = new Vector3(point.x / transform.localScale.x, point.y / transform.localScale.y, point.z / transform.localScale.z);
		
		int x = (int)point.x;
		int z = (int)point.z;
		
		int xPlusOne = x + 1;
		int zPlusOne = z + 1;
		
		if(xPlusOne >= width || zPlusOne >= depth || x < 0 || z < 0)
		{
			return Vector3.up;
		}
		
		Vector3 triZ0 = (vertices[z * depth + x]);
		Vector3 triZ1 = (vertices[z * depth + xPlusOne]);
		Vector3 triZ2 = (vertices[zPlusOne * depth + x]);
		Vector3 triZ3 = (vertices[zPlusOne * depth + xPlusOne]);
		
		Vector3 normal;

		float sqX = point.x - x;
		float sqZ = point.z - z;


		if ((sqX + sqZ) < 1)
		{
			Vector3 dif1 = (triZ2 - triZ0);
			Vector3 dif2 = (triZ1 - triZ0);

			dif1 = new Vector3(dif1.x * transform.localScale.x, dif1.y * transform.localScale.y, dif1.z * transform.localScale.z);
			dif2 = new Vector3(dif2.x * transform.localScale.x, dif2.y * transform.localScale.y, dif2.z * transform.localScale.z);

			normal = Vector3.Cross(dif1,dif2).normalized;
		}		
		else
		{
			Vector3 dif1 = (triZ3 - triZ1);
			Vector3 dif2 = (triZ3 - triZ2);

			dif1 = new Vector3(dif1.x * transform.localScale.x, dif1.y * transform.localScale.y, dif1.z * transform.localScale.z);
			dif2 = new Vector3(dif2.x * transform.localScale.x, dif2.y * transform.localScale.y, dif2.z * transform.localScale.z);

			normal = Vector3.Cross(dif1,dif2).normalized;
		}
		
		return normal;
		
	}

	public bool runWaves = false;

	void Update () {
		if(runWaves)
		{
			Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
			
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
}
