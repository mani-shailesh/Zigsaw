using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class displayResult : MonoBehaviour {
	Text result;
	// Use this for initialization
	void Start () {
		string[] scores = new string[1];
		result = GetComponent<Text> ();
		try{
			scores = System.IO.File.ReadAllLines(@"Scores.txt");
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
		using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Scores.txt", true))
		{
			file.WriteLine(frontPanel.userName + " : " + CheckStatus.timer.text);
		}
		result.text += "\nYeah! "+frontPanel.userName+", You got it in " + CheckStatus.timer.text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
