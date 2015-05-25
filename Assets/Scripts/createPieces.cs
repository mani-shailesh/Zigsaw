using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class createPieces : MonoBehaviour {
	public Texture2D myImage;
	public GameObject piece;
	GameObject newPiece;
	public int noOfCols, noOfRows;
	int noOfSlices;
	// Use this for initialization
	void Start () {
		GetComponent<GridLayoutGroup>().cellSize = new Vector2 (200/noOfRows, 200/noOfCols);
		noOfSlices = noOfCols * noOfRows;
		int width = myImage.width / noOfCols;
		int height = myImage.height / noOfRows;
		int offsetX = 0;
		int offsetY = myImage.height-height;
		int cnt = 0;
		//myImage = Resources.Load<Texture2D> ("windows.jpg");
		//Image part = GetComponentInChildren<Image> ();
		Texture2D[] tempPart = new Texture2D[noOfSlices];
		for (int row=1; row<=noOfRows; row++) {
			offsetX=0;
			for(int col=1; col<=noOfCols; col++){
				newPiece = Instantiate<GameObject>(piece);
				newPiece.transform.SetParent(transform);
				newPiece.GetComponentsInChildren<Image>()[1].name = (cnt+1).ToString();
				newPiece.GetComponent<GridLayoutGroup>().cellSize = new Vector2 (200/noOfRows, 200/noOfCols);
				tempPart[cnt] = new Texture2D (width, height);
				tempPart[cnt].SetPixels (myImage.GetPixels (offsetX, offsetY, width, height));
				tempPart[cnt].Apply ();
				offsetX+=width;
				GetComponentsInChildren<Image>()[(cnt+1)*2].GetComponent<Image>().sprite = 
					Sprite.Create(tempPart[cnt], new Rect(0, 0, width, height), new Vector2(0.5f, 0.0f));
				cnt++;
			}
			offsetY-=height;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
