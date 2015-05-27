using UnityEngine;
using System.Collections;

public class splashScript : MonoBehaviour {
	public static Texture2D gameImage;
	public static string userName;
	public static int level;
	string path;
	// Use this for initialization
	void Start () {
		gameImage = new Texture2D(1000, 1000);
		string[] settings = new string[1];
		try{
			settings = System.IO.File.ReadAllLines(@"Settings.txt");
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
		putImage();
		Application.LoadLevel("game");
	}
	void putImage(){
		if (path.Length != 0) {
			WWW www = new WWW("file:///" + path);
			www.LoadImageIntoTexture(gameImage);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
