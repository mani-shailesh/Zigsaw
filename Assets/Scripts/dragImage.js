#pragma strict
//import UnityEngine.EventSystems;
//var itemBeingDragged : GameObject;
var startPosition : Vector3;
//var startParent : Transform;
function Start () {
	print('Start');
	//OnMouseDown;
	OnMouseDrag();
}
function OnMouseDown (){
	print('Up');
	//itemBeingDragged = gameObject;
	startPosition = transform.position;
}
function OnMouseUp (){
	transform.position = startPosition;
	//itemBeingDragged = null;
}
function OnMouseDrag (){
	transform.position = startPosition;
}
function Update () {
}