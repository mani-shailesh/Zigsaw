using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class startGame : MonoBehaviour {
	public GameObject slotsPrefab;
	public GameObject piecesPrefab;
	Vector3 slotsPos, piecesPos;
	Quaternion rot;
	GameObject pieces, slots;
	// Use this for initialization
	void Start () {
		Vector2 slotsSize = new Vector2(Screen.height/2, Screen.height/2);
		slotsPos = new Vector3(Screen.width/2, Screen.height-slotsSize.y/2, 0);
		rot = Quaternion.identity;
		slotsPrefab.GetComponent<RectTransform>().sizeDelta = slotsSize;
		slots = (GameObject)Instantiate(slotsPrefab, slotsPos, rot);
		slots.transform.SetParent(transform);
		//print (slots.GetComponent<RectTransform>().sizeDelta);
		//slots.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2(5, 5);
		slots.name = "Slots";
		//Instantiate (piecesPrefab, piecesPos, rot);
		Vector2 piecesSize = new Vector2(Screen.width-20, Screen.height/2);
		piecesPos = new Vector3(Screen.width/2, piecesSize.y/2, 0);
		rot = Quaternion.identity;
		piecesPrefab.GetComponent<RectTransform>().sizeDelta = piecesSize;
		pieces = (GameObject)Instantiate(piecesPrefab, piecesPos, rot);
		pieces.transform.SetParent(transform);
		//print (slots.GetComponent<RectTransform>().sizeDelta);
		//slots.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2(5, 5);
		pieces.name = "Pieces";

	}
	public void onClickQuit(){
		Application.LoadLevel("splash");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
