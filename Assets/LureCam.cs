using UnityEngine;
using System.Collections;

public class LureCam : MonoBehaviour {
	
	//Define variable

	
	//The scene's default fog settings
	private bool defaultFog;
	private Color defaultFogColor;
	private float defaultFogDensity;
	private Material defaultSkybox;
	private Material noSkybox;
	private float defaultFogStartDistance;
	private float defaultFogEndDistance;

	void Start () {
		startY = transform.position.y;

		defaultFog = RenderSettings.fog;
		defaultFogColor = RenderSettings.fogColor;
		defaultFogDensity = RenderSettings.fogDensity;
		defaultSkybox = RenderSettings.skybox;
		defaultFogStartDistance = RenderSettings.fogStartDistance;
		defaultFogEndDistance = RenderSettings.fogEndDistance;
	}

	public Color fogColor;
	public float fogDensity = .04f;
	public float fogStartDistance = 5f;
	public float fogEndDistance = 10f;

	public void onFog() {
		RenderSettings.fog = true;
		RenderSettings.fogColor = fogColor;
		RenderSettings.fogDensity = fogDensity;
		RenderSettings.skybox = noSkybox;
		RenderSettings.fogStartDistance = fogStartDistance;
		RenderSettings.fogEndDistance = fogEndDistance;
		RenderSettings.fogMode = FogMode.Linear;
		camera.backgroundColor = fogColor;
	}

	public void offFog() {
		RenderSettings.fog = defaultFog;
		RenderSettings.fogColor = defaultFogColor;
		RenderSettings.fogDensity = defaultFogDensity;
		RenderSettings.skybox = defaultSkybox;
		RenderSettings.fogStartDistance = defaultFogStartDistance;
		RenderSettings.fogEndDistance = defaultFogEndDistance;
		camera.backgroundColor = Color.white;
	}

	public float underwaterLevel = 0f;
	bool underWater = false;
	void OnPreRender() {
		if(underWater)
		{
			onFog();
		}
	}

	void OnPostRender() {
		offFog();
	}


	//Starting y position
	float startY;

	//The lure this camera is following
	public Transform target;

	public Texture texture;

	Vector2 hookPoint;

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(hookPoint.x - 10, hookPoint.y - 15, 20, 30),texture); 
	}

	// Update is called once per frame
	void Update () {
		if(target.transform.position.y < startY)
		{
			transform.position = new Vector3(transform.position.x, target.transform.position.y + target.rigidbody.velocity.y * .2f, transform.position.z);




		}

		hookPoint = camera.WorldToScreenPoint(target.position);
		hookPoint = new Vector2(hookPoint.x, camera.pixelHeight - hookPoint.y);

		//transform.LookAt(target.transform.position);

		if(transform.position.y < underwaterLevel)
		{
			underWater = true;
		}
		else
		{
			underWater = false;
		}
	}
}
