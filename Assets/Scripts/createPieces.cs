using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class createPieces : MonoBehaviour {
	Texture2D myImage;
	public GameObject piece;
	GameObject newPiece;
	public int noOfCols, noOfRows;
	int noOfSlices;
	// Use this for initialization
	void Start () {
		myImage = frontPanel.gameImage;
		noOfCols = noOfRows = frontPanel.level;
		Rect slotsRect = GameObject.Find ("Slots").GetComponent<RectTransform> ().rect; 
		GetComponent<GridLayoutGroup>().cellSize = new Vector2 (slotsRect.width/noOfCols, slotsRect.height/noOfRows);
		noOfSlices = noOfCols * noOfRows;
		int width = myImage.width / noOfCols;
		int height = myImage.height / noOfRows;
		int offsetX = 0;
		int offsetY = myImage.height-height;
		int cnt = 0;
		//myImage = Resources.Load<Texture2D> ("windows.jpg");
		//Image part = GetComponentInChildren<Image> ();
		int[] partNames = new int[noOfSlices];
		Texture2D[] tempPart = new Texture2D[noOfSlices];
		for (int row=1; row<=noOfRows; row++) {
			offsetX = 0;
			for(int col=1; col<=noOfCols; col++){
				partNames[cnt] = cnt+1;
				tempPart[cnt] = new Texture2D (width, height);
				tempPart[cnt].SetPixels (myImage.GetPixels (offsetX, offsetY, width, height));
				tempPart[cnt].Apply ();
				cnt++;
				offsetX+=width;
			}
			offsetY-=height;
		}
		cnt = 0;
		for (int row=1; row<=noOfRows; row++) {
			for(int col=1; col<=noOfCols; col++){
				int rndNo = Random.Range(0, noOfSlices-cnt);
				Texture2D temp = tempPart[rndNo];
				int tempName = partNames[rndNo];
				tempPart[rndNo] = tempPart[noOfSlices-cnt-1];
				partNames[rndNo] = partNames[noOfSlices-cnt-1];
				tempPart[noOfSlices-cnt-1] = temp;
				partNames[noOfSlices-cnt-1] = tempName;
				newPiece = Instantiate<GameObject>(piece);
				newPiece.transform.SetParent(transform);
				newPiece.GetComponentsInChildren<Image>()[1].name = partNames[noOfSlices-cnt-1].ToString();
				newPiece.GetComponent<GridLayoutGroup>().cellSize = new Vector2 (slotsRect.width/noOfCols, slotsRect.height/noOfRows);
				GetComponentsInChildren<Image>()[(cnt+1)*2].GetComponent<Image>().sprite = 
					Sprite.Create(tempPart[noOfSlices-cnt-1], new Rect(0, 0, width, height), new Vector2(0.5f, 0.0f));
				cnt++;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
