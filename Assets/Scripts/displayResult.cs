using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class displayResult : MonoBehaviour {
	Text result;
	string userName;
	// Use this for initialization
	void Start () {
		userName = splashScript.userName;
		string[] scores = new string[1];
		result = GetComponent<Text> ();
		try{
			scores = System.IO.File.ReadAllLines(Application.persistentDataPath+"/Scores.txt");
		}catch{
			print ("File not found");
		}
		int i;
		if (scores.Length <= 3) {
			i = 0;
		} else {
			i = scores.Length-3;
		}
		result.text = "Previous Scores\n";
		for (; i<scores.Length; i++) {
			result.text+=(scores[i]+"\n");
		}
		using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.persistentDataPath+"/Scores.txt", true))
		{
			file.WriteLine(userName + " : " + CheckStatus.timer.text);
		}
		result.text += "\nYeah! "+userName+", You got it in " + CheckStatus.timer.text;
	}
	public void onClickReplay(){
		Application.LoadLevel("splash");
	}
	public void onClickQuit(){
		Application.Quit();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
