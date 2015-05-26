using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class frontPanel : MonoBehaviour {
	public static int level;
	string userName;
	// Use this for initialization
	void Start () {
		level = 2;
	}

	public void proceed(){
		level = (int)GameObject.Find ("Level").GetComponent<Slider> ().value;
		userName = GameObject.Find ("Name").GetComponentsInChildren<Text> () [1].GetComponent<Text> ().text;
		if (userName!="") {
			Application.LoadLevel("game");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
