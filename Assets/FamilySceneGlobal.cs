using UnityEngine;
using System.Collections;



public class FamilySceneGlobal : MonoBehaviour {
	
	public class Person
	{
		// Field 
		public string name;
		public int health;
		public int hunger;
		public int happy;
		public bool alive;
		
		// Constructor that takes one argument. 
		public Person(string n)
		{
			name = n;
			health = 5;
			hunger = 2;
			happy = 3;
			alive = true;
		}
		
		// Method 
		public void feed()
		{
			if(health < 10)
				health += 1;
			else Debug.Log("full health.");
			
			if(hunger > 0)
				hunger -=1;
			else Debug.Log("full stomach.");
			
			if(happy < 3)
				happy += 1;
			else Debug.Log("full happy.");
			
			FamilySceneGlobal.fish-=1;
		}
	}

	public static System.Collections.Generic.List<Person> family = new System.Collections.Generic.List<Person>();

	// fish should be how many fish caught that day
	public static int fish = 0;
	public static int ltemp = 0;
	public static int ntemp = 0;
	public static int ttemp = 0;

	public static int happy = 6;
	//public static Person hero = new Person("The Hero");
	public static Person wife = new Person("The Wife");
	public static Person child = new Person("The Child");
	public static Person baby = new Person("The Baby");
	public static Person dog = new Person("The Dog");
	// Use this for initialization
	void Start () 
	{
		//family.Add(hero);
		Debug.Log(TimeKeepTracker.day);
		if(TimeKeepTracker.day==1){ family.Add(wife); family.Add(baby);family.Add(child); family.Add(dog);}
		fish=FishCollect.getFishCollected();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
