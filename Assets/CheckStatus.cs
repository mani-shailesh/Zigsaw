using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CheckStatus : MonoBehaviour {
	int noOfPieces = 4;
	bool isFinished = false;
	Component[] slots;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		slots = GetComponentsInChildren<Image> ();
		if (slots.Length-(noOfPieces+1) == noOfPieces && isFinished==false) {
			for (int i=3, j=1; i<=slots.Length; i+=2, j++) {
				if (!slots [i - 1].name.Equals(((i-1)/2).ToString(), System.StringComparison.Ordinal)) {
					return;
				}
			}
			print ("Success");
			isFinished=true;
		}
	}
}
