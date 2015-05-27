using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class frontPanel : MonoBehaviour {
	public static int level;
	string path;
	public static string userName;
	InputField pathBox;
	InputField nameBox;
	Slider levelBar;
	// Use this for initialization
	void Start () {
		level = 2;
		levelBar = GameObject.Find ("Level").GetComponent<Slider> ();
		nameBox = GameObject.Find ("Name").GetComponent<InputField> ();
		pathBox = GameObject.Find ("Path").GetComponent<InputField>();
		string[] settings = new string[1];
		try{
			settings = System.IO.File.ReadAllLines(@"Settings.txt");
			pathBox.text = settings[1];
			nameBox.text = settings[0];
			levelBar.value = int.Parse(settings[2]);
		}catch{
			print ("File not found");
		}
	}
	public void onClickCancel(){
		Application.LoadLevel("splash");
	}
	public void proceed(){
		level = (int)levelBar.value;
		userName = nameBox.text;
		path = pathBox.text;
		if (userName!="" && path!="") {
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Settings.txt"))
			{
				file.WriteLine(userName);
				file.WriteLine(path);
				file.WriteLine(level.ToString());
				file.Close();
			}
			Application.LoadLevel("splash");
		}
	}
	public void browseImage(){
#if UNITY_EDITOR		
		path = EditorUtility.OpenFilePanel("Select Image", "", "jpg");
		pathBox.text = path;
#endif
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
