using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class startGame : MonoBehaviour {
	public GameObject slotsPrefab;
	public GameObject piecesPanelPrefab;
	public GameObject splashPanel;
	GameObject piecesPanel;
	GameObject newSplashPanel;
	Button splashButton;
	Vector3 slotsPos, piecesPanelPos;
	Quaternion rot;
	RectTransform menuRectTransform;
	int noOfCols, noOfRows;
	GameObject slots;
	int marginTop;
	int marginSides, panelGap;
	int marginDown;
	int scrollBarWidth;
	int splashGameCount;
	int framesSinceSplashed;
	int gameWidth, gameHeight;
	Texture2D myImage;
	bool isImageSplashed;
	// Use this for initialization
	void Start () {
		isImageSplashed = false;
		myImage = splashScript.gameImage;
		splashGameCount = 0;
		marginTop = 30;
		marginDown = 5;
		marginSides = panelGap = 5;
		scrollBarWidth = 20;
		gameWidth = Screen.width - 2*marginSides - panelGap;
		gameHeight = Screen.height - marginTop - marginDown;
		noOfCols = noOfRows = splashScript.level;
		splashButton = GameObject.Find("Splash").GetComponent<Button>();
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
	public void onClickSplash(){
		splashGameCount+=1;
		if(splashGameCount<=3){
			splashImage();
		}
		if(splashGameCount>=3){
			splashButton.interactable = false;
		}
	}

	void splashImage(){
		splashPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
		newSplashPanel = (GameObject)Instantiate(splashPanel, new Vector3(Screen.width/2, Screen.height/2, 0), rot);
		newSplashPanel.transform.SetParent(transform);
		newSplashPanel.name = "SplashPanel";
		newSplashPanel.GetComponentsInChildren<Image>()[1].GetComponent<Image>().sprite = 
			Sprite.Create(myImage, new Rect(0, 0, myImage.width, myImage.height), new Vector2(0.5f, 0.0f));
		isImageSplashed = true;
		framesSinceSplashed = 0;
	}
	// Update is called once per frame
	void Update () {
		if(isImageSplashed){
			framesSinceSplashed+=1;
			if(framesSinceSplashed>=60){
				Destroy(newSplashPanel);
			}
		}
	}
}
