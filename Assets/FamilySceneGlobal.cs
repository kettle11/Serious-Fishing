using UnityEngine;
using System.Collections;

public class Person
{
	// Field 
	public string name;
	public int health;
	public int hunger;
	public int happy;

	// Constructor that takes one argument. 
	public Person(string n)
	{
		name = n;
		health = 10;
		hunger = 0;
		happy = 3;
	}
	
	// Method 
	public void feed()
	{
		if(health < 10)
			health += 1;
		if(hunger > 0)
			hunger -=1;
		if(happy < 3)
			happy += 1;
	}
}


public class FamilySceneGlobal : MonoBehaviour {

	//List<Person> family = new List<Person>();
	// Use this for initialization
	void Start () 
	{
		Person hero = new Person("The Hero");
		Person wife = new Person("The Wife");
		Person child = new Person("The Child");
		Person baby = new Person("The Baby");
		Person dog = new Person("The Dog");

		Debug.Log(hero.name);
		//family.Add(hero); family.Add(wife); family.Add(child); family.Add(baby); family.Add(dog);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
