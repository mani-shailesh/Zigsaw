using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class splashScript : MonoBehaviour {
	public static Texture2D gameImage;
	public static string userName;
	public static int level;
	Text messageBox;
	string path;
	// Use this for initialization
	void Start () {
		messageBox = GameObject.Find("Message").GetComponent<Text>();
		gameImage = new Texture2D(1000, 1000);
		string[] settings = new string[1];
		try{
			print (Application.persistentDataPath);
			settings = System.IO.File.ReadAllLines(Application.persistentDataPath+"/Settings.txt");
		}catch{
			Application.LoadLevel("front");
			print ("File not found");
		}
		if (settings.Length <= 1) {
			Application.LoadLevel("front");
		}
		else{
			userName = settings[0];
			path = settings[1];
			level = int.Parse(settings[2]);
		}
	}

	public void onClickSettings(){
		Application.LoadLevel("front");
	}
	public void onClickPlay(){
		if(System.IO.File.Exists(path)){
			putImage();
			Application.LoadLevel("game");
		}else{
			messageBox.text = "Image not found!!! Please try changing path in settings...";
		}
	}
	public void onClickQuit(){
		Application.Quit();
	}
	void putImage(){
		WWW www = new WWW("file:///" + path);
		www.LoadImageIntoTexture(gameImage);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
