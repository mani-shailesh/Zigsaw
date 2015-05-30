using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Diagnostics;
public class CheckStatus : MonoBehaviour {
	public GameObject slot;
	GameObject newSlot;
	int noOfRows, noOfCols;
	Stopwatch stopwatch = new Stopwatch();
	TimeSpan timeElapsed;
	bool isFinished = false;
	int noOfPieces;
	Vector2 cellSizeVector;
	public static Text timer;
	Component[] slots;
	// Use this for initialization
	void Start () {
		noOfRows = noOfCols = splashScript.level;
		Rect slotsRect = GetComponent<RectTransform> ().rect; 
		//float heightRatio = (float)Screen.height/346;
		//float widthRatio = (float)Screen.width/800;
		//slotsRect.width = slotsRect.width*widthRatio;
		//slotsRect.height = slotsRect.height*heightRatio;
		print (slotsRect.width);
		print(slotsRect.height);
		cellSizeVector = new Vector2((slotsRect.width-noOfCols)/noOfCols, (slotsRect.height-noOfRows)/noOfRows);
		//cellSizeVector = new Vector2 ((slotsRect.width)/noOfCols, (slotsRect.height)/noOfRows);
		GetComponent<GridLayoutGroup>().cellSize = cellSizeVector;
		noOfPieces = noOfCols * noOfRows;
		//noOfPieces = createPieces.noOfRows*createPieces.noOfCols;
		for (int i=1; i<=noOfPieces; i++) {
			newSlot = Instantiate(slot);
			newSlot.name = i.ToString();
			newSlot.transform.SetParent(transform);
			newSlot.GetComponent<GridLayoutGroup>().cellSize = cellSizeVector;
		}
		stopwatch.Start ();
		timer = GameObject.Find("Timer").GetComponent<Text>();
		timer.text = "00 : 00";
	}
	// Update is called once per frame
	void Update () {
		timeElapsed = stopwatch.Elapsed;
		//stopwatch.Stop ();
		timer.text = String.Format ("{0:00}:{1:00}", timeElapsed.Minutes, timeElapsed.Seconds);
		//stopwatch.Start ();
		slots = GetComponentsInChildren<Image> ();
		if (slots.Length-(noOfPieces+1) == noOfPieces && isFinished==false) {
			for (int i=3, j=1; i<=slots.Length; i+=2, j++) {
				if (!slots [i - 1].name.Equals(((i-1)/2).ToString(), System.StringComparison.Ordinal)) {
					return;
				}
			}
			print ("Success");
			stopwatch.Stop();
			isFinished=true;
			Application.LoadLevel("result");
		}
	}
}
