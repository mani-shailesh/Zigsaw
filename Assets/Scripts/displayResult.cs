using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class displayResult : MonoBehaviour {
	Text result;
	// Use this for initialization
	void Start () {
		result = GetComponent<Text> ();
		result.text = "Yeah! You got it in " + CheckStatus.timer.text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
