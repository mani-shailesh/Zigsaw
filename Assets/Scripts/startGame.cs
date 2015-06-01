using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class startGame : MonoBehaviour {
	public GameObject slotsPrefab;
	public GameObject piecesPanelPrefab;
	GameObject piecesPanel;
	Vector3 slotsPos, piecesPanelPos;
	Quaternion rot;
	RectTransform menuRectTransform;
	int noOfCols, noOfRows;
	GameObject slots;
	// Use this for initialization
	void Start () {
		noOfCols = noOfRows = splashScript.level;
		Vector2 slotsSize = new Vector2((((Screen.width-20)-noOfCols)/(noOfCols+1))*noOfCols, Screen.height);
		slotsPos = new Vector3(slotsSize.x/2, Screen.height/2, 0);
		rot = Quaternion.identity;
		slotsPrefab.GetComponent<RectTransform>().sizeDelta = slotsSize;
		slots = (GameObject)Instantiate(slotsPrefab, slotsPos, rot);
		slots.transform.SetParent(transform);
		slots.name = "Slots";
		Vector2 piecesSize = new Vector2(Screen.width-slotsSize.x, (Screen.height)/noOfRows*noOfCols*noOfRows);
		piecesPanelPos = new Vector3(Screen.width-piecesSize.x/2, (Screen.height-60)/2+60, 0);
		rot = Quaternion.identity;
		piecesPanelPrefab.GetComponent<RectTransform>().sizeDelta = new Vector2(piecesSize.x, Screen.height-60);
		piecesPanel = (GameObject)Instantiate(piecesPanelPrefab, piecesPanelPos, rot);
		GameObject.Find("Pieces").GetComponent<RectTransform>().sizeDelta = new Vector2(piecesSize.x-20, piecesSize.y);
		piecesPanel.transform.SetParent(transform);
		piecesPanel.name = "PiecesPanel";

	}
	public void onClickQuit(){
		Application.LoadLevel("splash");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
