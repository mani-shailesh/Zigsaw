using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Diagnostics;
public class CheckStatus : MonoBehaviour {
	public GameObject slot;
	GameObject newSlot;
	public int noOfRows, noOfCols;
	Stopwatch stopwatch = new Stopwatch();
	TimeSpan timeElapsed;
	bool isFinished = false;
	int noOfPieces;
	public static Text timer;
	Component[] slots;
	// Use this for initialization
	void Start () {
		GetComponent<GridLayoutGroup>().cellSize = new Vector2 (200/noOfRows, 200/noOfCols);
		noOfPieces = noOfCols * noOfRows;
		//noOfPieces = createPieces.noOfRows*createPieces.noOfCols;
		for (int i=1; i<=noOfPieces; i++) {
			newSlot = Instantiate(slot);
			newSlot.name = i.ToString();
			newSlot.transform.SetParent(transform);
			newSlot.GetComponent<GridLayoutGroup>().cellSize = new Vector2 (200/noOfRows, 200/noOfCols);
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
