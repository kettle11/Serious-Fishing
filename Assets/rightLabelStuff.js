#pragma strict
#pragma strict

var happy  = 5;
var hunger = 3;
var fish   = 1;
 
function OnMouseDown()
{
 
}

function OnMouseEnter() {
	gameObject.guiText.color = Color.red;
}
function OnMouseExit() {
	gameObject.guiText.color = Color.green;
}
function Start () {
	gameObject.guiText.text = "Status of Family\n" +  "Happiness: " + happy + "\nHunger: " + hunger + "\nFish: " + fish + "\n";
}

function Update () {

}