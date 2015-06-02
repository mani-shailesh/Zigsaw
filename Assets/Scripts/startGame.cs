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
	int marginTop;
	int marginSides, panelGap;
	int marginDown;
	int scrollBarWidth;
	int gameWidth, gameHeight;
	// Use this for initialization
	void Start () {
		marginTop = 30;
		marginDown = 5;
		marginSides = panelGap = 5;
		scrollBarWidth = 20;
		gameWidth = Screen.width - 2*marginSides - panelGap;
		gameHeight = Screen.height - marginTop - marginDown;
		noOfCols = noOfRows = splashScript.level;
		GameObject.Find("Name").GetComponentInChildren<Text>().text = splashScript.userName;
		Vector2 slotsSize = new Vector2((((gameWidth-scrollBarWidth)-noOfCols)/(noOfCols+1))*noOfCols, gameHeight);
		slotsPos = new Vector3(slotsSize.x/2 + marginSides, gameHeight/2+marginDown, 0);
		rot = Quaternion.identity;
		slotsPrefab.GetComponent<RectTransform>().sizeDelta = slotsSize;
		slots = (GameObject)Instantiate(slotsPrefab, slotsPos, rot);
		slots.transform.SetParent(transform);
		slots.name = "Slots";
		Vector2 piecesSize = new Vector2(gameWidth-slotsSize.x, (gameHeight)/noOfRows*noOfCols*noOfRows);
		piecesPanelPos = new Vector3(gameWidth-piecesSize.x/2+marginSides+panelGap, (gameHeight)/2+marginDown, 0);
		rot = Quaternion.identity;
		piecesPanelPrefab.GetComponent<RectTransform>().sizeDelta = new Vector2(piecesSize.x, gameHeight);
		piecesPanel = (GameObject)Instantiate(piecesPanelPrefab, piecesPanelPos, rot);
		GameObject.Find("Pieces").GetComponent<RectTransform>().sizeDelta = new Vector2(piecesSize.x-scrollBarWidth, piecesSize.y);
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
